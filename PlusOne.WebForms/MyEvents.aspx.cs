using System;
using System.Linq;
using Microsoft.AspNet.Identity;
using PlusOne.Data.Models;
using PlusOne.MVP.EventCreate;
using PlusOne.MVP.Events;
using PlusOne.MVP.MyEvents;
using WebFormsMvp;
using WebFormsMvp.Web;

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