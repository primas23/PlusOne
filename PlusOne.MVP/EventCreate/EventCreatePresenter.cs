using System;
using PlusOne.Data.Models;
using PlusOne.Services;
using WebFormsMvp;
using Microsoft.AspNet.Identity;

namespace PlusOne.MVP.EventCreate
{
    public class EventCreatePresenter : Presenter<IEventCreateView>
    {
        private readonly IEventService _eventService;
        private readonly IEventTypeService _eventTypeService;

        public EventCreatePresenter(IEventCreateView view, IEventService eventService, IEventTypeService eventTypeService)
            : base(view)
        {
            this._eventService = eventService;
            this._eventTypeService = eventTypeService;

            this.View.OnGetEventTypes += this.View_OnGetEventTypes;
            this.View.OnEventCreate += this.View_OnEventCreate;
        }

        private void View_OnGetEventTypes(object sender, EventCreateEventArgs e)
        {
            this.View.Model.EventTypes = this._eventTypeService.GetAllEventTypes();
        }

        private void View_OnEventCreate(object sender, IdEventArgs e)
        {
            Event eventToinsertEvent = new Event()
            {
                TypeId = this.View.Model.EventTypeId,
                Start = this.View.Model.Start,
                End = this.View.Model.End,
                Location = new Location()
                {
                    Name = this.View.Model.LocationName,
                    Address = this.View.Model.LocationAddress,
                    Longitude = this.View.Model.Longitude,
                    Latitude = this.View.Model.Latitude
                },
                ApplicationUserId = e.Id
            };

            this._eventService.InsertEvent(eventToinsertEvent);

            this.View.Model.EventTypeId = eventToinsertEvent.Id;
        }
    }
}
