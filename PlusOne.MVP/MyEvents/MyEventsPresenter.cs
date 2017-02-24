using PlusOne.Services;
using WebFormsMvp;

namespace PlusOne.MVP.MyEvents
{
    public class MyEventsPresenter : Presenter<IMyEventsView>
    {
        private readonly IEventService _eventService;


        public MyEventsPresenter(IMyEventsView view, IEventService eventService) 
            : base(view)
        {
            this._eventService = eventService;

            this.View.OnEventsGetData += this.View_OnEventsGetData;
        }

        private void View_OnEventsGetData(object sender, EventCreate.IdEventArgs e)
        {
            this.View.Model.Events = this._eventService.GetAllMyEventsSortedByStartDate(e.Id);
        }
    }
}
