using Airline.Application.Grpc;
using Airline.Application.Validators;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineApplication
{
    [TestFixture]
    public class FlightsRequestValidatorTests
    {
        private FlightsRequestValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new FlightsRequestValidator();
        }

        [Test]
        public void Validate_WithValidRequest_ShouldPassValidation()
        {
            // Arrange
            var request = new FlightsRequest
            {
                ArrivalLocation = "City A",
                DepartureLocation = "City B",
                From = Timestamp.FromDateTime( DateTime.UtcNow.AddMinutes(1)),
                To = Timestamp.FromDateTime(DateTime.UtcNow.AddHours(1))
            };

            // Act
            var result = _validator.Validate(request);

            // Assert
            Assert.IsTrue(result.IsValid);
        }

        [Test]
        public void Validate_WithMissingArrivalLocation_ShouldFailValidation()
        {
            // Arrange
            var request = new FlightsRequest
            {
                DepartureLocation = "City B",
                From = Timestamp.FromDateTime(DateTime.UtcNow.AddMinutes(1)),
                To = Timestamp.FromDateTime(DateTime.UtcNow.AddHours(1))
            };

            // Act
            var result = _validator.Validate(request);

            // Assert
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual("Arrival location must be provided.", result.Errors[0].ErrorMessage);
        }

        [Test]
        public void Validate_WithMissingDepartureLocation_ShouldFailValidation()
        {
            // Arrange
            var request = new FlightsRequest
            {
                ArrivalLocation = "City A",
                From = Timestamp.FromDateTime(DateTime.UtcNow.AddMinutes(1)),
                To = Timestamp.FromDateTime(DateTime.UtcNow.AddHours(1))
            };

            // Act
            var result = _validator.Validate(request);

            // Assert
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual("Departure location must be provided.", result.Errors[0].ErrorMessage);
        }

        [Test]
        public void Validate_WithInvalidArrivalDate_ShouldFailValidation()
        {
            // Arrange
            var request = new FlightsRequest
            {
                ArrivalLocation = "City A",
                DepartureLocation = "City B",
                From = Timestamp.FromDateTime(DateTime.UtcNow.AddMinutes(1)),
                To = Timestamp.FromDateTime(DateTime.UtcNow.AddHours(-1)) // Set the arrival date in the past
            };

            // Act
            var result = _validator.Validate(request);

            // Assert
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual("Arrival date must be in the future or today.", result.Errors[0].ErrorMessage);
        }

        [Test]
        public void Validate_WithInvalidDepartureDate_ShouldFailValidation()
        {
            // Arrange
            var request = new FlightsRequest
            {
                ArrivalLocation = "City A",
                DepartureLocation = "City B",
                From = Timestamp.FromDateTime(DateTime.UtcNow.AddHours(-1)), // Set the departure date in the past
                To = Timestamp.FromDateTime(DateTime.UtcNow.AddHours(1))
            };

            // Act
            var result = _validator.Validate(request);

            // Assert
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual("Departure date must be in the future or today.", result.Errors[0].ErrorMessage);
        }

        [Test]
        public void Validate_WithInvalidDateRange_ShouldFailValidation()
        {
            // Arrange
            var request = new FlightsRequest
            {
                ArrivalLocation = "City A",
                DepartureLocation = "City B",
                From = Timestamp.FromDateTime(DateTime.UtcNow.AddHours(2)), // Set the departure date after the arrival date
                To = Timestamp.FromDateTime(DateTime.UtcNow.AddHours(1))
            };

            // Act
            var result = _validator.Validate(request);

            // Assert
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual("The departure date must be earlier than the arrival date.", result.Errors[0].ErrorMessage);
        }
    }

}
