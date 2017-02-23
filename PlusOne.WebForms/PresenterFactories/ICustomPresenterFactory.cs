using System;
using WebFormsMvp;

namespace PlusOne.WebForms.PresenterFactories
{
    public interface ICustomPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, IView viewInstance);
    }
}
