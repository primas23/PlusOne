using System;
using PlusOne.MVP.EventDetails;
using WebFormsMvp;

namespace PlusOne.MVP.EventCreate
{
    public interface IEventCreateView : IView<EventCreateViewModel>
    {
        event EventHandler<EventCreateEventArgs> OnGetEventTypes;

        event EventHandler<IdEventArgs> OnEventCreate;
    }
}
