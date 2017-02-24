using System;

using Moq;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

using PlusOne.MVP.EventCreate;
using PlusOne.Services;
using PlusOne.Data.Models;

namespace PlusOne.Test.MVP.EventCreatePresenter
{
    [TestFixture]
    public class View_OnEventCreate
    {
        [Test]
        public void ShouldReturnCorrect_WhenCorrectIsSupplied()
        {
            var viewMock = new Mock<IEventCreateView>();
            var eventServiceMock = new Mock<IEventService>();
            var eventTypeServiceMock = new Mock<IEventTypeService>();
            Guid eventId = Guid.NewGuid();

            viewMock.Setup(v => v.Model.Start).Returns(DateTime.Now);
            viewMock.Setup(v => v.Model.End).Returns(DateTime.Now);
            viewMock.Setup(v => v.Model.EventTypeId).Returns(eventId);
            viewMock.Setup(v => v.Model.Latitude).Returns(12321321);
            viewMock.Setup(v => v.Model.Longitude).Returns(12321321);
            viewMock.Setup(v => v.Model.LocationAddress).Returns("asdasd");
            viewMock.Setup(v => v.Model.LocationName).Returns("asdasd");

            var createPresenter = new PlusOne.MVP.EventCreate.EventCreatePresenter(
                viewMock.Object,
                eventServiceMock.Object,
                eventTypeServiceMock.Object);

            viewMock.Raise(v => v.OnEventCreate += null, new IdEventArgs() { Id = eventId });

            Assert.AreEqual(eventId, viewMock.Object.Model.EventTypeId);
        }

        [Test]
        public void ShouldCallInsert_WhenCorrectIsSupplied()
        {
            var viewMock = new Mock<IEventCreateView>();
            var eventServiceMock = new Mock<IEventService>();
            var eventTypeServiceMock = new Mock<IEventTypeService>();
            Guid eventId = Guid.NewGuid();

            viewMock.Setup(v => v.Model.Start).Returns(DateTime.Now);
            viewMock.Setup(v => v.Model.End).Returns(DateTime.Now);
            viewMock.Setup(v => v.Model.EventTypeId).Returns(eventId);
            viewMock.Setup(v => v.Model.Latitude).Returns(12321321);
            viewMock.Setup(v => v.Model.Longitude).Returns(12321321);
            viewMock.Setup(v => v.Model.LocationAddress).Returns("asdasd");
            viewMock.Setup(v => v.Model.LocationName).Returns("asdasd");

            var createPresenter = new PlusOne.MVP.EventCreate.EventCreatePresenter(
                viewMock.Object,
                eventServiceMock.Object,
                eventTypeServiceMock.Object);

            viewMock.Raise(v => v.OnEventCreate += null, new IdEventArgs() { Id = eventId });

            eventServiceMock.Verify(v => v.InsertEvent(It.IsAny<Event>()), Times.AtLeastOnce);
        }
    }
}
