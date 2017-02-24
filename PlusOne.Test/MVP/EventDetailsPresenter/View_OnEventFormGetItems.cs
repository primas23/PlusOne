using System;
using Moq;
using NUnit.Framework;
using PlusOne.MVP.EventCreate;
using PlusOne.Services;
using PlusOne.Data.Models;
using PlusOne.MVP.EventDetails;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PlusOne.Test.MVP.EventCreatePresenter
{
    [TestFixture]
    public class View_OnEventFormGetItems
    {
        [Test]
        public void ShouldCallFormGetItems_WhenCorrectIsSupplied()
        {
            var viewMock = new Mock<IEventDetailsView>();
            var eventServiceMock = new Mock<IEventService>();
            var eventTypeServiceMock = new Mock<IEventTypeService>();
            Guid eventId = Guid.NewGuid();

            var mockedEvent = new Event()
            {
                Id = eventId,
                Start = DateTime.Now,
                End = DateTime.Now,
                Location = new Location()
                {
                    Name = "ddd",
                    Latitude = 11231,
                    Longitude = 22442,
                    Address = "awesh",
                },
            };

            viewMock.Setup(v => v.Model.Event).Returns(mockedEvent);

            var createPresenter = new EventDetailsPresenter(
                viewMock.Object,
                eventServiceMock.Object);

            viewMock.Raise(v => v.OnFormGetItems += null, new FormGetItemsEventArgs(eventId));
            eventServiceMock.Verify(v => v.GetById(It.IsAny<Guid>()), Times.AtLeastOnce);
        }

        [Test]
        public void ShouldCallFormGetItems_WhenCorrectIsSupplied()
        {
            var viewMock = new Mock<IEventDetailsView>();
            var eventServiceMock = new Mock<IEventService>();
            var eventTypeServiceMock = new Mock<IEventTypeService>();
            Guid eventId = Guid.NewGuid();

            var mockedEvent = new Event()
            {
                Id = eventId,
                Start = DateTime.Now,
                End = DateTime.Now,
                Location = new Location()
                {
                    Name = "ddd",
                    Latitude = 11231,
                    Longitude = 22442,
                    Address = "awesh",
                },
            };

            viewMock.Setup(v => v.Model.Event).Returns(mockedEvent);

            var createPresenter = new EventDetailsPresenter(
                viewMock.Object,
                eventServiceMock.Object);

            viewMock.Raise(v => v.OnFormGetItems += null, new FormGetItemsEventArgs(eventId));
            eventServiceMock.Verify(v => v.GetById(It.IsAny<Guid>()), Times.AtLeastOnce);
        }
    }
}
