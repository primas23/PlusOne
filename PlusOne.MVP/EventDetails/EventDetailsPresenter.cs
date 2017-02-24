using PlusOne.Services;
using WebFormsMvp;

namespace PlusOne.MVP.EventDetails
{
    public class EventDetailsPresenter : Presenter<IEventDetailsView>
    {
        private readonly IEventService _eventService;

        public EventDetailsPresenter(IEventDetailsView view, IEventService eventService) 
            : base(view)
        {
            this._eventService = eventService;

            this.View.OnFormGetItems += this.View_OnFormGetItems;
            this.View.OnJoinEvent += this.View_OnJoinEvent;
            this.View.OnLeaveEvent += this.View_OnLeaveEvent;
        }

        private void View_OnLeaveEvent(object sender, EventJoinEventArgs e)
        {
            this._eventService.RemoveParticipant(e.EventId, e.UserId);
        }

        private void View_OnJoinEvent(object sender, EventJoinEventArgs e)
        {
            this._eventService.AddParticipant(e.EventId, e.UserId);
        }

        private void View_OnFormGetItems(object sender, FormGetItemsEventArgs e)
        {
            this.View.Model.Event = this._eventService.GetById(e.Id);
        }
    }
}
