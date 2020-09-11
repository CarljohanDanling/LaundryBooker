
namespace LaundryBooker.Tests.EngineTests
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Engine.Dto;
    using FluentAssertions;
    using DataLayer.Repository;
    using Engine.Services;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class BookingSessionServiceTests
    {
        private Mock<IBookingSessionService> _mockBookingSessionService;
        private Mock<IMapper> _mockIMapper;
        private Mock<IBookingSessionRepository> _mockBookingSessionRepository;

        //private DbContextOptions<LaundryContext> ReturnDbContextOptions(string databaseString)
        //{
        //    return new DbContextOptionsBuilder<LaundryContext>()
        //        .UseInMemoryDatabase(databaseName: databaseString)
        //        .Options;
        //}

        [SetUp]
        public void Setup()
        {
            _mockIMapper = new Mock<IMapper>();
            _mockBookingSessionRepository = new Mock<IBookingSessionRepository>();
            _mockBookingSessionService = new Mock<IBookingSessionService>();
        }

        [Test]
        [TestCase(0)]
        [TestCase(54)]
        public async Task GetSchedule_ShouldReturnError_WhenWeekNumberIsLessThanOneOrGreaterThan53(int weekNumber)
        {
            // Arrange
            var laundryRoomId = 0;

            _mockBookingSessionService.Setup(m => m.GetSchedule(laundryRoomId, weekNumber))
                .ThrowsAsync(new ArgumentOutOfRangeException());

            // Act
            var bookingSessionService = new BookingSessionService(_mockBookingSessionRepository.Object, _mockIMapper.Object);
            Func<Task> act = async () => await bookingSessionService.GetSchedule(laundryRoomId, weekNumber);

            // Assert
            await act.Should().ThrowAsync<ArgumentOutOfRangeException>();
        }

        [Test]
        public async Task GetSchedule_ShouldBeOk_WhenWeekNumberIsValid()
        {
            // Arrange
            var laundryRoomId = 0;
            var weekNumber = 5;

            _mockBookingSessionService.Setup(m => m.GetSchedule(laundryRoomId, weekNumber))
                .ReturnsAsync(new ScheduleDto());

            // Act
            var bookingSessionService = new BookingSessionService(_mockBookingSessionRepository.Object, _mockIMapper.Object);
            Func<Task> act = async () => await bookingSessionService.GetSchedule(laundryRoomId, weekNumber);

            // Assert
            await act.Should().NotThrowAsync<ArgumentOutOfRangeException>();
        }
    }
}