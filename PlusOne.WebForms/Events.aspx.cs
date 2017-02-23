using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlusOne.Data.Models;
using PlusOne.MVP.Events;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PlusOne.WebForms
{
    [PresenterBinding(typeof(EventsPresenter))]
    public partial class Events : MvpPage<EventsViewModel>, IEventsView
    {
        public event EventHandler OnEventsGetData;

        public IList<Event> ListViewEvents_GetData()
        {
            this.OnEventsGetData?.Invoke(this, null);

            return this.Model.Events;
        }

        protected void LinkButtonSearch_Click(object sender, EventArgs e)
        {
            //string textToSearchFor = this.TextBoxSearchParam.Text;
            //string queryParam = string.IsNullOrEmpty(textToSearchFor) ? string.Empty : string.Format("?q={0}", textToSearchFor);
            //Response.Redirect("~/search" + queryParam);
        }
    }
}