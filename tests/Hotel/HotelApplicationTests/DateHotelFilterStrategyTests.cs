using Hotel.Application.FlitersStrategies;
using Hotel.Application.Grpc;
using Hotel.Application.Interfaces;
using Moq;
using Hotel;
using Hotel.Models;
using FluentAssertions;
using System.Linq.Expressions;
using Google.Protobuf.WellKnownTypes;

namespace HotelApplicationTests
{
    [TestFixture]
    internal class DateHotelFilterStrategyTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private DateHotelFilterStrategy _filterStrategy;

        [SetUp]
        public void Setup()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _filterStrategy = new DateHotelFilterStrategy(_unitOfWorkMock.Object);
        }

        [Test]
        public async Task FilterHotelsAsync_ShouldReturnMatchingHotels()
        {
            // Arrange
            var request = new HotelsRequest
            {
                // Set the properties as needed
                Country = "USA",
                City = "New York",
                From = Timestamp.FromDateTime(DateTime.UtcNow),
                To = Timestamp.FromDateTime(DateTime.UtcNow.AddDays(4))
            };

            var matchingHotel = new Hotel.Models.Hotel
            {
                City = "New York",
                Country = "USA",
                OccupiedDates = new List<HotelOccupiedDate>
                {
                    new HotelOccupiedDate { OccupateDate = DateTime.UtcNow.AddDays(6) },
                    new HotelOccupiedDate { OccupateDate = DateTime.UtcNow.AddDays(8) },
                    new HotelOccupiedDate { OccupateDate = DateTime.UtcNow.AddDays(10) },
                }
            };

            var nonMatchingHotel = new Hotel.Models.Hotel
            {
                City = "New York",
                Country = "USA",
                OccupiedDates = new List<HotelOccupiedDate>
                {
                    new HotelOccupiedDate { OccupateDate = DateTime.UtcNow.AddDays(1) },
                    new HotelOccupiedDate { OccupateDate = DateTime.UtcNow.AddDays(2) },
                    new HotelOccupiedDate { OccupateDate = DateTime.UtcNow.AddDays(4) },
                }
            };


            Expression<Func<Hotel.Models.Hotel, bool>> expression = _filterStrategy.IsHotelMatch(request);
            bool isNotMatch = expression.Compile().Invoke(nonMatchingHotel);

            isNotMatch.Should().BeFalse();

            bool isMatch = expression.Compile().Invoke(matchingHotel);

            isMatch.Should().BeTrue();
        }

        [Test]
        public async Task FilterHotelsAsync_ShouldReturnEmptyList_WhenNoMatchingHotels()
        {
            // Arrange
            var request = new HotelsRequest
            {
                // Set the properties as needed
                Country = "USA",
                City = "New York",
                From = Timestamp.FromDateTime(DateTime.UtcNow),
                To = Timestamp.FromDateTime(DateTime.UtcNow.AddDays(4))
            };

            var nonMatchingHotel = new Hotel.Models.Hotel
            {
                City = "Los Angeles",
                Country = "USA",
                OccupiedDates = new List<HotelOccupiedDate>
                {
                    new HotelOccupiedDate { OccupateDate = DateTime.UtcNow.AddDays(6) },
                    new HotelOccupiedDate { OccupateDate = DateTime.UtcNow.AddDays(8) },
                    new HotelOccupiedDate { OccupateDate = DateTime.UtcNow.AddDays(10) },
                }
            };

            Expression<Func<Hotel.Models.Hotel, bool>> expression = _filterStrategy.IsHotelMatch(request);
            bool isNotMatch = expression.Compile().Invoke(nonMatchingHotel);

            isNotMatch.Should().BeFalse();
        }
    }
}
