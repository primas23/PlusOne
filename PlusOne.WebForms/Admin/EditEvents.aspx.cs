using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.ModelBinding;
using System.Web.UI.WebControls;
using PlusOne.Data.Models;
using PlusOne.MVP.EditEvents;
using PlusOne.MVP.EventCreate;
using PlusOne.MVP.Events;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PlusOne.WebForms.Admin
{
    [PresenterBinding(typeof(EventsPresenter))]
    public partial class EditEvents : MvpPage<EventsViewModel>, IEventsView
    {
        public event EventHandler OnEventsGetData;

        public event EventHandler OnGetAllEventsData;

        public event EventHandler<IdEventArgs> OnDeleteMethod;

        public event EventHandler<IdEventArgs> OnUpdateMethod;

        public IQueryable<Event> ListViewEvents_GetData()
        {
            this.OnGetAllEventsData?.Invoke(this, null);
            
            return this.Model.Events;
        }

        public void ListView1_DeleteItem(string id)
        {
            this.OnDeleteMethod?.Invoke(this, new IdEventArgs() { Id = Guid.Parse(id) });
        }

        public void ListView1_UpdateItem(string id)
        {
            this.OnUpdateMethod?.Invoke(this, new IdEventArgs() {Id = Guid.Parse(id) });
        }
    }
}