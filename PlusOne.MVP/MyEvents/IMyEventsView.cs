using System;
using PlusOne.MVP.EventCreate;
using PlusOne.MVP.Events;
using WebFormsMvp;

namespace PlusOne.MVP.MyEvents
{
    public interface IMyEventsView : IView<EventsViewModel>
    {
        event EventHandler<IdEventArgs> OnEventsGetData;
    }
}
