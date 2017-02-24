using System;

using Moq;
using NUnit.Framework;

using PlusOne.Services;
using PlusOne.Data.Models;
using PlusOne.MVP.EventDetails;

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
        public void ShouldCallView_OnJoinEvent_WhenCorrectIsSupplied()
        {
            var viewMock = new Mock<IEventDetailsView>();
            var eventServiceMock = new Mock<IEventService>();

            Guid eventId = Guid.NewGuid();
            string userId = String.Empty;

            var createPresenter = new EventDetailsPresenter(
                viewMock.Object,
                eventServiceMock.Object);

            viewMock.Raise(v => v.OnJoinEvent += null, new EventJoinEventArgs() {UserId = userId, EventId = eventId});
            eventServiceMock.Verify(v => v.AddParticipant(It.IsAny<Guid>(), It.IsAny<string>()), Times.AtLeastOnce);
        }


        [Test]
        public void ShouldCallView_OnLeaveEvent_WhenCorrectIsSupplied()
        {
            var viewMock = new Mock<IEventDetailsView>();
            var eventServiceMock = new Mock<IEventService>();

            Guid eventId = Guid.NewGuid();
            string userId = String.Empty;

            var createPresenter = new EventDetailsPresenter(
                viewMock.Object,
                eventServiceMock.Object);

            viewMock.Raise(v => v.OnLeaveEvent += null, new EventJoinEventArgs() { UserId = userId, EventId = eventId });
            eventServiceMock.Verify(v => v.RemoveParticipant(It.IsAny<Guid>(), It.IsAny<string>()), Times.AtLeastOnce);
        }
    }
}
