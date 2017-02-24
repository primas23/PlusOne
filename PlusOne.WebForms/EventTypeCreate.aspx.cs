using System;
using PlusOne.MVP.EventType;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PlusOne.WebForms
{
    [PresenterBinding(typeof(EventTypeCreatePresenter))]
    public partial class EventTypeCreate : MvpPage<EventTypeCreateViewModel>, IEventTypeCreateView
    {
        public event EventHandler<NameEventArgs> OnEventTypeCreate;

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            string eventTypeName = this.EventType.Text;
            
            this.OnEventTypeCreate?.Invoke(this, new NameEventArgs() { Name = eventTypeName });

            Response.Redirect("~/eventcreate.aspx");
        }
    }
}