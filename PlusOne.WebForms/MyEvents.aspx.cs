using System;
using System.Linq;

using WebFormsMvp;
using WebFormsMvp.Web;

using Microsoft.AspNet.Identity;

using PlusOne.Data.Models;
using PlusOne.MVP.EventCreate;
using PlusOne.MVP.Events;
using PlusOne.MVP.MyEvents;

namespace PlusOne.WebForms
{
    [PresenterBinding(typeof(MyEventsPresenter))]
    public partial class MyEvents : MvpPage<EventsViewModel>, IMyEventsView
    {
        public event EventHandler<IdEventArgs> OnEventsGetData;

        public IQueryable<Event> MyListViewEvents_GetData()
        {
            this.OnEventsGetData?.Invoke(this, new IdEventArgs() { Id = Guid.Parse(this.Context.User.Identity.GetUserId()) });

            return this.Model.Events;
        }
    }
}