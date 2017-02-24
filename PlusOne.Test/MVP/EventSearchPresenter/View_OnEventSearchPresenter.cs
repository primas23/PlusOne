using System;
using System.Collections.Generic;
using System.Linq;

using Moq;
using NUnit.Framework;

using PlusOne.Data.Models;
using PlusOne.MVP.Search;
using PlusOne.Services;

namespace PlusOne.Test.MVP.EventCreatePresenter
{
    [TestFixture]
    public class View_OnEventSearchPresenter
    {
        [Test]
        public void ShouldCallView_OnJoinEvent_WhenCorrectIsSupplied()
        {
            var viewMock = new Mock<ISearchView>();
            var eventServiceMock = new Mock<IEventService>();


            viewMock.Setup(v => v.Model.Events).Returns(new List<Event>() as IQueryable<Event>);

            var createPresenter = new SearchPresenter(
                viewMock.Object,
                eventServiceMock.Object);

            var searchEventArgs = new SearchEventArgs("test1", "test2", DateTime.Now, DateTime.Now);

            viewMock.Raise(v => v.OnRepeaterGetData += null, searchEventArgs);
            eventServiceMock.Verify(v => v.GetAllEventsBySearchParams(It.IsAny<string>(), It.IsAny<string>(), 
                It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.AtLeastOnce);
        }


    }
}
