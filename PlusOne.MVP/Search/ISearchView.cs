using System;
using WebFormsMvp;

namespace PlusOne.MVP.Search
{
    public interface ISearchView : IView<SearchViewModel>
    {
        event EventHandler<SearchEventArgs> OnRepeaterGetData;
    }
}
