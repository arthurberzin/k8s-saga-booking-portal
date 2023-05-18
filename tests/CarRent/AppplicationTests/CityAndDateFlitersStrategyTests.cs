using CarRent.Application.FlitersStrategies;
using CarRent.Application.Grpc;
using CarRent.Application.Interfaces;
using CarRent.Models;
using FluentAssertions;
using Google.Protobuf.WellKnownTypes;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppplicationTests
{
    internal class CityAndDateFlitersStrategyTests
    {
        private CityAndDateFlitersStrategy _filterStrategy;

        [SetUp]
        public void Setup()
        {
            // Create an instance of the CityAndDateFlitersStrategy with a mock IUnitOfWork
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            _filterStrategy = new CityAndDateFlitersStrategy(unitOfWorkMock.Object);
        }

        [Test]
        public void IsCarMatch_WhenCarMatchesFilters_ShouldReturnTrue()
        {
            // Arrange
            var request = new CarsRequest
            {
                Country = "USA",
                City = "New York",
                From = Timestamp.FromDateTime( DateTime.UtcNow),
                To = Timestamp.FromDateTime(DateTime.UtcNow.AddDays(7))
            };

            var car = new Car
            {
                CurrentLocation = new Location
                {
                    Country = "USA",
                    City = "New York"
                },
                OccupiedDates = new List<CarOccupiedDate>()
            };

            // Act
            Expression<Func<Car, bool>> expression = _filterStrategy.IsCarMatch(request);
            bool isMatch = expression.Compile().Invoke(car);

            // Assert
            isMatch.Should().BeTrue();
        }

        [Test]
        public void IsCarMatch_WhenCarDoesNotMatchFilters_ShouldReturnFalse()
        {
            // Arrange
            var request = new CarsRequest
            {
                Country = "USA",
                City = "New York",
                From = Timestamp.FromDateTime(DateTime.UtcNow),
                To = Timestamp.FromDateTime(DateTime.UtcNow.AddDays(7))
            };

            var car = new Car
            {
                CurrentLocation = new Location
                {
                    Country = "USA",
                    City = "Los Angeles"
                },
                OccupiedDates = new List<CarOccupiedDate>()
            };

            // Act
            Expression<Func<Car, bool>> expression = _filterStrategy.IsCarMatch(request);
            bool isMatch = expression.Compile().Invoke(car);

            // Assert
            isMatch.Should().BeFalse();
        }

        [Test]
        public void IsCarMatch_WhenCarIsOccupiedDuringRequestedDates_ShouldReturnFalse()
        {
            // Arrange
            var request = new CarsRequest
            {
                Country = "USA",
                City = "New York",
                From = Timestamp.FromDateTime(DateTime.UtcNow),
                To = Timestamp.FromDateTime(DateTime.UtcNow.AddDays(7))
            };

            var car = new Car
            {
                CurrentLocation = new Location
                {
                    Country = "USA",
                    City = "New York"
                },
                OccupiedDates = new List<CarOccupiedDate>
                    {
                        new CarOccupiedDate { OccupateDate = DateTime.UtcNow.AddDays(2) },
                        new CarOccupiedDate { OccupateDate = DateTime.UtcNow.AddDays(4) },
                        new CarOccupiedDate { OccupateDate = DateTime.UtcNow.AddDays(6) }
                    }
            };

            // Act
            Expression<Func<Car, bool>> expression = _filterStrategy.IsCarMatch(request);
            bool isMatch = expression.Compile().Invoke(car);

            // Assert
            isMatch.Should().BeFalse();
        }
    }
}
