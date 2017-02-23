using System;

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
