using System;
using System.Web.ModelBinding;

using WebFormsMvp;

using PlusOne.MVP.EventCreate;

namespace PlusOne.MVP.Events
{
    public interface IEventsView : IView<EventsViewModel>
    {
        event EventHandler OnEventsGetData;

        event EventHandler OnGetAllEventsData;

        event EventHandler<IdEventArgs> OnDeleteMethod;

        event EventHandler<IdEventArgs> OnUpdateMethod;

        ModelStateDictionary ModelState { get; }

        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }
}
