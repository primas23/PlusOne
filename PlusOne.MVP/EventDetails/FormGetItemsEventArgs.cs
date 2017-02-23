using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusOne.MVP.EventDetails
{
    public class FormGetItemsEventArgs : EventArgs
    {
        public Guid? Id { get; private set; }

        public FormGetItemsEventArgs(Guid? id)
        {
            this.Id = id;
        }
    }
}
