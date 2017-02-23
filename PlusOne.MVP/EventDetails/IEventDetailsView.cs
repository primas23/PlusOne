using System;
using WebFormsMvp;

namespace PlusOne.MVP.EventDetails
{
    public interface IEventDetailsView : IView<EventDetailsViewModel>
    {
        event EventHandler<FormGetItemsEventArgs> OnFormGetItems;
    }
}
