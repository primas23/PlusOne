using System;

using WebFormsMvp;

using PlusOne.MVP.EventCreate;
using PlusOne.MVP.Events;

namespace PlusOne.MVP.MyEvents
{
    public interface IMyEventsView : IView<EventsViewModel>
    {
        event EventHandler<IdEventArgs> OnEventsGetData;
    }
}
