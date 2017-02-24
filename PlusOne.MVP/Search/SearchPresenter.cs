using WebFormsMvp;

using PlusOne.Services;

namespace PlusOne.MVP.Search
{
    public class SearchPresenter : Presenter<ISearchView>
    {
        private readonly IEventService _eventService;

        public SearchPresenter(ISearchView view, IEventService eventService) 
            : base(view)
        {
            this._eventService = eventService;

            this.View.OnRepeaterGetData += this.View_OnRepeaterGetData;
        }

        private void View_OnRepeaterGetData(object sender, SearchEventArgs e)
        {
            this.View.Model.Events = this._eventService.GetAllEventsBySearchParams(e.QueryType, e.QueryLocation, e.QueryStart, e.QueryEnd);
        }
    }
}
