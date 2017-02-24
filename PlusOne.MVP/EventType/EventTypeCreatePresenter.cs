using WebFormsMvp;

using PlusOne.Services;

namespace PlusOne.MVP.EventType
{
    public class EventTypeCreatePresenter : Presenter<IEventTypeCreateView>
    {
        private readonly IEventTypeService _eventTypeService;

        public EventTypeCreatePresenter(IEventTypeCreateView view, IEventTypeService eventTypeService)
            : base(view)
        {
            this._eventTypeService = eventTypeService;

            this.View.OnEventTypeCreate += this.View_OnEventTypeCreate;
        }

        private void View_OnEventTypeCreate(object sender, NameEventArgs e)
        {
            Data.Models.EventType eventType = new Data.Models.EventType()
            {
                Name = e.Name
            };

            this._eventTypeService.InsertEvent(eventType);
        }
    }
}
