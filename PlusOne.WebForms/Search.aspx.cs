using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.ModelBinding;
using PlusOne.Data.Models;
using PlusOne.MVP.Search;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PlusOne.WebForms
{
    [PresenterBinding(typeof(SearchPresenter))]
    public partial class Search : MvpPage<SearchViewModel>, ISearchView
    {
        public event EventHandler<SearchEventArgs> OnRepeaterGetData;

        public IList<Event> Reapeater_GetData([QueryString] string type, [QueryString] string location, [QueryString] string start, [QueryString] string end)
        {
            DateTime startData = string.IsNullOrEmpty(start) ? DateTime.MinValue : DateTime.Parse(start);
            DateTime endData = string.IsNullOrEmpty(end) ? DateTime.MaxValue : DateTime.Parse(end);
            
            this.OnRepeaterGetData?.Invoke(this, new SearchEventArgs(type, location, startData, endData));

            return this.Model.Events.ToList();
        }
    }
}