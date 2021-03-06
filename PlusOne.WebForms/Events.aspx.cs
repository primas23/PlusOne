﻿using System;
using System.Linq;
using PlusOne.Data.Models;
using PlusOne.MVP.EventCreate;
using PlusOne.MVP.Events;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PlusOne.WebForms
{
    [PresenterBinding(typeof(EventsPresenter))]
    public partial class Events : MvpPage<EventsViewModel>, IEventsView
    {
        public event EventHandler OnEventsGetData;

        public event EventHandler OnGetAllEventsData;

        public event EventHandler<IdEventArgs> OnDeleteMethod;

        public event EventHandler<IdEventArgs> OnUpdateMethod;

        public IQueryable<Event> ListViewEvents_GetData()
        {
            this.OnEventsGetData?.Invoke(this, null);

            return this.Model.Events;
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            string eventType = this.TextBoxSearchParamEvent.Text;
            string eventLocation = this.TextBoxSearchParamLocation.Text;
            string eventStartData = this.TextBoxSearchParamStartData.Text;
            string eventEndData = this.TextBoxSearchParamEndData.Text;

            string queryParams = string.Format("?type={0}&location={1}&start={2}&end={3}", eventType, eventLocation, eventStartData, eventEndData);

            Response.Redirect("~/search" + queryParams);
        }
    }
}