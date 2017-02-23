using System;

namespace PlusOne.MVP.Search
{
    public class SearchEventArgs : EventArgs
    {
        public string QueryType { get; private set; }
        public string QueryLocation { get; private set; }
        public DateTime QueryStart { get; private set; }
        public DateTime QueryEnd { get; private set; }

        public SearchEventArgs(string queryType, string queryLocation, DateTime queryStart, DateTime queryEnd)
        {
            this.QueryType = queryType;
            this.QueryLocation = queryLocation;
            this.QueryStart = queryStart;
            this.QueryEnd = queryEnd;
        }
    }
}
