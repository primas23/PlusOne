using System;

using WebFormsMvp;

using PlusOne.Data.Models;
using PlusOne.MVP.EventCreate;
using PlusOne.Services;

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
            this.View.OnGetAllEventsData += this.View_OnGetAllEventsData;
            this.View.OnDeleteMethod += this.View_OnDeleteMethod;
            this.View.OnUpdateMethod += this.View_OnUpdateMethod;
        }

        private void View_OnUpdateMethod(object sender, IdEventArgs e)
        {
            Event evnetToUpdatEvent = this._eventService.GetById(e.Id);
            if (evnetToUpdatEvent == null)
            {
                // The item wasn't found
                this.View.ModelState.AddModelError(string.Empty, string.Format("Item with id {0} was not found", e.Id));
                return;
            }

            this.View.TryUpdateModel(evnetToUpdatEvent);
            if (this.View.ModelState.IsValid)
            {
                this._eventService.UpdateEvent(evnetToUpdatEvent);
            }
        }

        private void View_OnDeleteMethod(object sender, IdEventArgs e)
        {
            this._eventService.DeleteEvent(e.Id);
        }

        private void View_OnGetAllEventsData(object sender, EventArgs e)
        {
            this.View.Model.Events = this._eventService.GetAllEventsInDataBase();
        }

        private void View_OnEventsGetData(object sender, EventArgs e)
        {
            this.View.Model.Events = this._eventService.GetAllEventsSortedByStartDate();
        }
    }
}
