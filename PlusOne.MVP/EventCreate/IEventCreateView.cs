using System;
using System.Web.ModelBinding;

using WebFormsMvp;

namespace PlusOne.MVP.EventCreate
{
    public interface IEventCreateView : IView<EventCreateViewModel>
    {
        event EventHandler OnGetEventTypes;

        event EventHandler<IdEventArgs> OnEventCreate;

        ModelStateDictionary ModelState { get; }

        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }
}
