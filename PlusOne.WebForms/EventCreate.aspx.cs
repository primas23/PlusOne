using System;
using System.Linq;
using Microsoft.AspNet.Identity;
using PlusOne.MVP.EventCreate;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PlusOne.WebForms
{
    [PresenterBinding(typeof(EventCreatePresenter))]
    public partial class EventCreate : MvpPage<EventCreateViewModel>, IEventCreateView
    {
        public event EventHandler<EventCreateEventArgs> OnGetEventTypes;
        public event EventHandler<IdEventArgs> OnEventCreate;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.OnGetEventTypes?.Invoke(this, null);

            this.DropDownListEventType.DataSource = this.Model.EventTypes.ToList();
            this.DropDownListEventType.DataBind();
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            string location = this.LocationName.Text;
            string startDate = this.StartDate.Text;
            string endDate = this.EndDate.Text;
            string latitude = this.Latitude.Text;
            string longitude = this.Longitude.Text;
            string locationAddress = this.LocationAddress.Text;
            string eventTypedDateId = this.DropDownListEventType.Text;

            // TODO: Validate

            this.Model.EventTypeId = Guid.Parse(eventTypedDateId);
            this.Model.Start = DateTime.Parse(startDate);
            this.Model.End = DateTime.Parse(endDate);
            this.Model.LocationName = location;
            this.Model.Latitude = double.Parse(latitude);
            this.Model.Longitude = double.Parse(longitude);
            this.Model.LocationAddress = locationAddress;

            Guid userId = Guid.Parse(this.Context.User.Identity.GetUserId());

            this.OnEventCreate?.Invoke(this, new IdEventArgs() {Id = userId});

            Response.Redirect(string.Format("~/eventdetails.aspx?id={0}", this.Model.EventTypeId));
        }
    }
}