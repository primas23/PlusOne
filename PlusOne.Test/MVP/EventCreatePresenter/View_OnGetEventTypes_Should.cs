using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using PlusOne.Data.Models;
using PlusOne.MVP.EventCreate;
using PlusOne.Services;

namespace PlusOne.Test.MVP.EventCreatePresenter
{
    [TestFixture]
    public class View_OnGetEventTypes_Should
    {
        [Test]
        public void AddModelError_WhenItemIsNotFound()
        {
            // Arrange
            var viewMock = new Mock<IEventCreateView>();
            var eventTypes = this.GetMockedEventTypes();

            var eventServiceMock = new Mock<IEventService>();
            var eventTypeServiceMock = new Mock<IEventTypeService>();
            eventTypeServiceMock.Setup(e => e.GetAllEventTypes()).Returns(eventTypes);

            PlusOne.MVP.EventCreate.EventCreatePresenter createPresenter = new PlusOne.MVP.EventCreate.EventCreatePresenter(
                viewMock.Object,
                eventServiceMock.Object,
                eventTypeServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnGetEventTypes += null, EventArgs.Empty);

            // Assert
            CollectionAssert.AreEquivalent(eventTypes, viewMock.Object.Model.EventTypes);
        }
        
        private IQueryable<EventType> GetMockedEventTypes()
        {
            return new List<EventType>()
            {
                new EventType()
                {
                    Id = Guid.NewGuid(),
                    Name = "Event 1",
                    IsDeleted = false
                },
                new EventType()
                {
                    Id = Guid.NewGuid(),
                    Name = "Event 1",
                    IsDeleted = false
                },

            }.AsQueryable();
        }
    }
}
