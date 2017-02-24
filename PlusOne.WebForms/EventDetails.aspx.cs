using System;
using System.Linq;
using System.Web.ModelBinding;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using PlusOne.Data.Models;
using PlusOne.MVP.EventDetails;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PlusOne.WebForms
{
    [PresenterBinding(typeof(EventDetailsPresenter))]
    public partial class EventDetails : MvpPage<EventDetailsViewModel>, IEventDetailsView
    {
        public event EventHandler<FormGetItemsEventArgs> OnFormGetItems;

        public event EventHandler<EventJoinEventArgs> OnJoinEvent;

        public event EventHandler<EventJoinEventArgs> OnLeaveEvent;

        public Event FormViewEventDetails_GetItem([QueryString] Guid? id)
        {
            this.OnFormGetItems?.Invoke(this, new FormGetItemsEventArgs(id));

            bool isMaxCapacity = this.Model.Event.MaxParticipants <= this.Model.Event.Participants.Count;
            bool isJoined = this.Model.Event.Participants.Any(p => p.Id == this.Context.User.Identity.GetUserId());

            this.LeaveButton.Style.Add("display", "none");

            this.JoinButton.Style.Add("display", isMaxCapacity ? "none" : "inline");
            
            if (isJoined)
            {
                this.JoinButton.Style.Add("display", "none");
                this.LeaveButton.Style.Add("display", "inline");
            }

            if (this.Model.Event.End < DateTime.Now)
            {
                this.JoinButton.Style.Add("display", "none");
                this.LeaveButton.Style.Add("display", "none");
            }

            return this.Model.Event;
        }

        protected void JoinButton_OnClick(object sender, CommandEventArgs e)
        {
            this.OnJoinEvent?.Invoke(this, new EventJoinEventArgs()
            {
                EventId = Guid.Parse(e.CommandArgument.ToString()),
                UserId = this.Context.User.Identity.GetUserId()
            });
        }

        protected void LeaveButton_OnClick(object sender, CommandEventArgs e)
        {
            this.OnLeaveEvent?.Invoke(this, new EventJoinEventArgs()
            {
                EventId = Guid.Parse(e.CommandArgument.ToString()),
                UserId = this.Context.User.Identity.GetUserId()
            });
        }
    }
}