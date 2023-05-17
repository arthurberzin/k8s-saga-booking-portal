using Airline.Application.FilterStrategies;
using Airline.Application.Grpc;
using Airline.Application.Interfaces;
using Airline.Models;
using Google.Protobuf.WellKnownTypes;
using Moq;
using System.Linq.Expressions;

namespace AirlineApplication
{
    public class FilterStrategyTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private DepartureAndArrivalLocationFilterStrategy _filterStrategy;

        [SetUp]
        public void Setup()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _filterStrategy = new DepartureAndArrivalLocationFilterStrategy(_unitOfWorkMock.Object);
        }


        [Test]
        public void IsFlightMatch_ReturnsExpressionForMatchingFlights()
        {
            // Arrange
            var request = new FlightsRequest
            {
                DepartureLocation = "City A",
                ArrivalLocation = "City B",
                From = Timestamp.FromDateTime(DateTime.UtcNow),
                To = Timestamp.FromDateTime( DateTime.UtcNow.AddDays(1))
            };

            // Act
            Expression<Func<Flight, bool>> expression = _filterStrategy.IsFlightMatch(request);

            // Compile the expression to a delegate function
            Func<Flight, bool> matchFunction = expression.Compile();

            // Create sample flights
            var matchingFlight1 = new Flight
            {
                DepartureAirport = new Airport { City = "City A" },
                ArrivalAirport = new Airport { City = "City B" },
                DepartureDateTime = DateTime.UtcNow,
                ArrivalDateTime = DateTime.UtcNow.AddHours(2)
            };

            var matchingFlight2 = new Flight
            {
                DepartureAirport = new Airport { City = "City A" },
                ArrivalAirport = new Airport { City = "City B" },
                DepartureDateTime = DateTime.UtcNow.AddHours(1),
                ArrivalDateTime = DateTime.UtcNow.AddHours(3)
            };

            var matchingFlight3 = new Flight
            {
                DepartureAirport = new Airport { City = "City a" },
                ArrivalAirport = new Airport { City = "City b" },
                DepartureDateTime = DateTime.UtcNow.AddHours(1),
                ArrivalDateTime = DateTime.UtcNow.AddHours(3)
            };

            var nonMatchingFlight1 = new Flight
            {
                DepartureAirport = new Airport { City = "City C" },
                ArrivalAirport = new Airport { City = "City D" },
                DepartureDateTime = DateTime.UtcNow,
                ArrivalDateTime = DateTime.UtcNow.AddHours(3)
            };

            var nonMatchingFlight2 = new Flight
            {
                DepartureAirport = new Airport { City = "City A" },
                ArrivalAirport = new Airport { City = "City D" },
                DepartureDateTime = DateTime.UtcNow,
                ArrivalDateTime = DateTime.UtcNow.AddHours(2)
            };

            var nonMatchingFlight3 = new Flight
            {
                DepartureAirport = new Airport { City = "City C" },
                ArrivalAirport = new Airport { City = "City B" },
                DepartureDateTime = DateTime.UtcNow,
                ArrivalDateTime = DateTime.UtcNow.AddHours(2)
            };

            var nonMatchingFlight4 = new Flight
            {
                DepartureAirport = new Airport { City = "City A" },
                ArrivalAirport = new Airport { City = "City B" },
                DepartureDateTime = DateTime.UtcNow.AddHours(-2),
                ArrivalDateTime = DateTime.UtcNow.AddHours(2)
            };

            // Assert
            Assert.IsTrue(matchFunction(matchingFlight1));
            Assert.IsTrue(matchFunction(matchingFlight2));
            Assert.IsTrue(matchFunction(matchingFlight3));
            Assert.IsFalse(matchFunction(nonMatchingFlight1));
            Assert.IsFalse(matchFunction(nonMatchingFlight2));
            Assert.IsFalse(matchFunction(nonMatchingFlight3));
            Assert.IsFalse(matchFunction(nonMatchingFlight4));
        }
    }
    }