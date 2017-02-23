using System;
using System.Web.ModelBinding;
using System.Web.UI;
using PlusOne.Data.Models;
using PlusOne.MVP.EventDetails;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PlusOne.WebForms
{
    [PresenterBinding(typeof(EventDetailsPresenter))]
    public partial class EventDetails : MvpPage<EventDetailsViewModel>, IEventDetailsView
    {
        public event EventHandler<FormGetItemsEventArgs> OnFormGetItems;

        public Event FormViewEventDetails_GetItem([QueryString] Guid? id)
        {
            this.OnFormGetItems?.Invoke(this, new FormGetItemsEventArgs(id));

            return this.Model.Event;
        }
    }
}