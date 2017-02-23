using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlusOne.Services;
using WebFormsMvp;

namespace PlusOne.MVP.EventDetails
{
    public class EventDetailsPresenter : Presenter<IEventDetailsView>
    {
        private readonly IEventService _eventService;

        public EventDetailsPresenter(IEventDetailsView view, IEventService eventService) 
            : base(view)
        {
            this._eventService = eventService;

            this.View.OnFormGetItems += this.View_OnFormGetItems;
        }

        private void View_OnFormGetItems(object sender, FormGetItemsEventArgs e)
        {
            this.View.Model.Event = this._eventService.GetById(e.Id);
        }
    }
}
