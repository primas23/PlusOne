using System;
using WebFormsMvp;

namespace PlusOne.MVP.Events
{
    public interface IEventsView : IView<EventsViewModel>
    {
        event EventHandler OnEventsGetData;
    }
}
