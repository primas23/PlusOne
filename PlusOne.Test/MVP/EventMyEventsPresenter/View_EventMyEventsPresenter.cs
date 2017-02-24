using System;
using Moq;
using NUnit.Framework;
using PlusOne.MVP.EventCreate;
using PlusOne.Services;
using PlusOne.Data.Models;
using PlusOne.MVP.EventDetails;
using PlusOne.MVP.Search;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using System.Collections.Generic;
using System.Linq;
using PlusOne.MVP.MyEvents;

namespace PlusOne.Test.MVP.EventCreatePresenter
{
    [TestFixture]
    public class EventMyEventsPresenter
    {
        [Test]
        public void ShouldCallView_View_OnEventsGetData_WhenCorrectIsSupplied()
        {
            var viewMock = new Mock<IMyEventsView>();
            var eventServiceMock = new Mock<IEventService>();


            viewMock.Setup(v => v.Model.Events).Returns(new List<Event>() as IQueryable<Event>);

            var createPresenter = new MyEventsPresenter(
                viewMock.Object,
                eventServiceMock.Object);

            var idEventArgs = new IdEventArgs() {Id = Guid.NewGuid()};

            viewMock.Raise(v => v.OnEventsGetData += null, idEventArgs);

            eventServiceMock.Verify(v => v.GetAllMyEventsSortedByStartDate(It.IsAny<Guid>()), Times.AtLeastOnce);
        }


    }
}
