using System;
using WebFormsMvp;

namespace PlusOne.MVP.EventType
{
    public interface IEventTypeCreateView : IView<EventTypeCreateViewModel>
    {
        event EventHandler<NameEventArgs> OnEventTypeCreate;
    }
}
