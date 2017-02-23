using PlusOne.Services;
using System;
using WebFormsMvp;

namespace PlusOne.MVP.Events
{
    public class EventsPresenter : Presenter<IEventsView>
    {
        private readonly IEventService _eventService;

        public EventsPresenter(IEventsView view, IEventService eventService) 
            : base(view)
        {
            this._eventService = eventService;

            this.View.OnEventsGetData += this.View_OnEventsGetData;
        }

        private void View_OnEventsGetData(object sender, EventArgs e)
        {
            this.View.Model.Events = this._eventService.GetAllEventsSortedByStartDate();
        }
    }
}
