using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Net;
using TMS.Api.Controllers;
using TMS.Api.Entities;
using TMS.Api.Models;
using TMS.Api.Repositories;

namespace TMS.UnitTests
{
    [TestClass]
    public class EventsControllerTest
    {
        Mock<IEventRepository> _eventRepositoryMock;
        Mock<IEventTypeRepository> _eventTypeMoq;
        Mock<IMapper> _mapperMoq;
        List<Event> _moqList;
        List<EventDto> _dtoMoq;

        [TestInitialize]
        public void SetupMoqData()
        {
            _eventRepositoryMock = new Mock<IEventRepository>();
            _eventTypeMoq = new Mock<IEventTypeRepository>();
            _mapperMoq = new Mock<IMapper>();
            _moqList = new List<Event>
            {
                new Event {EventId = 1,
                    EventName = "Moq name",
                    EventDescription = "Moq description",
                    EndDate = DateTime.Now,
                    StartDate = DateTime.Now,
                    EventType = new EventType {EventTypeId = 1,EventTypeName="test event type"},
                    EventTypeId = 1,
                    Venue = new Venue {VenueId = 1,Capacity = 12, Location = "Mock location",Type = "mock type"},
                    VenueId = 1
                }
            };
            _dtoMoq = new List<EventDto>
            {
                new EventDto
                {
                    EndDate = DateTime.Now,
                    EventDescription = "Moq description",
                    EventId = 1,
                    EventName = "Moq name",
                    EventType = new EventType {EventTypeId = 1,EventTypeName="test event type"},
                    StartDate = DateTime.Now,
                    Venue = new Venue {VenueId = 1,Capacity = 12, Location = "Mock location",Type = "mock type"}
                }
            };
        }

        [TestMethod]
        public async Task GetAllEventsReturnListOfEvents()
        {
            //Arrange

            IReadOnlyList<Event> moqEvents = _moqList;
            Task<IReadOnlyList<Event>> moqTask = Task.Run(() => moqEvents);
            _eventRepositoryMock.Setup(moq => moq.GetAllAsync()).Returns(moqTask);

            _mapperMoq.Setup(moq => moq.Map<IEnumerable<EventDto>>(It.IsAny<IReadOnlyList<Event>>())).Returns(_dtoMoq);

            var controller = new EventsController(_eventRepositoryMock.Object, _eventTypeMoq.Object, _mapperMoq.Object);

            //Act
            var events = await controller.GetEvents();
            var eventResult = events.Result as OkObjectResult;
            var eventCount = eventResult.Value as IList;

            //Assert
            
            Assert.AreEqual(_moqList.Count, eventCount.Count);
        }

        [TestMethod]
        public async Task GetEventByIdReturnNotFoundWhenNoRecordFound()
        {
            //Arrange
            _eventRepositoryMock.Setup(moq => moq.GetByIdAsync(It.IsAny<int>())).Returns(Task.Run(() =>_moqList.First()));
            _mapperMoq.Setup(moq => moq.Map<IEnumerable<EventDto>>(It.IsAny<IReadOnlyList<Event>>())).Returns((IEnumerable<EventDto>)null);
            var controller = new EventsController(_eventRepositoryMock.Object, _eventTypeMoq.Object, _mapperMoq.Object);
            //Act

            var result = await controller.GetEventById(1);
            var eventResult = result.Result as NotFoundResult;
            

            //Assert

            Assert.IsTrue(eventResult.StatusCode == 404);
        }

        [TestMethod]
        public async Task GetEventByIdReturnFirstRecord()
        {
            //Arrange
            _eventRepositoryMock.Setup(moq => moq.GetByIdAsync(It.IsAny<int>())).Returns(Task.Run(() => _moqList.First()));
            _mapperMoq.Setup(moq => moq.Map<EventDto>(It.IsAny<Event>())).Returns(_dtoMoq.First());
            var controller = new EventsController(_eventRepositoryMock.Object, _eventTypeMoq.Object, _mapperMoq.Object);
            //Act

            var result = await controller.GetEventById(1);
            var eventResult = result.Result as OkObjectResult;
            var eventCount = eventResult.Value as EventDto;

            //Assert

            Assert.IsFalse(string.IsNullOrEmpty(eventCount.EventName));
            Assert.AreEqual(1, eventCount.EventId);
        }

        [TestMethod]
        public async Task GetEventByIDThrowsAnException()
        {
            //Arrange
            _eventRepositoryMock.Setup(moq => moq.GetByIdAsync(It.IsAny<int>())).Throws<Exception>();
            _mapperMoq.Setup(moq => moq.Map<EventDto>(It.IsAny<Event>())).Returns(_dtoMoq.First());
            var controller = new EventsController(_eventRepositoryMock.Object, _eventTypeMoq.Object, _mapperMoq.Object);
            //Act

            var result = await controller.GetEventById(1);

            //Assert

            Assert.IsNull(result);
        }
    }
}