using CarRent.Application.Grpc;
using CarRent.Application.Validators;
using FluentAssertions;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppplicationTests
{
    internal class CarRequestValidatorTests
    {
        private CarsRequestValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new CarsRequestValidator();
        }

        [Test]
        public void ShouldHaveErrorWhenCountryIsNotProvided()
        {
            // Arrange
            var request = new CarsRequest
            {
                City = "New York",
                From = Timestamp.FromDateTime(DateTime.UtcNow),
                To = Timestamp.FromDateTime(DateTime.UtcNow.AddDays(1))
            };

            // Act
            var result = _validator.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().Which.ErrorMessage.Should().Be("Country must be provided.");
        }

        [Test]
        public void ShouldHaveErrorWhenCityIsNotProvided()
        {
            // Arrange
            var request = new CarsRequest
            {
                Country = "USA",
                From = Timestamp.FromDateTime(DateTime.UtcNow),
                To = Timestamp.FromDateTime(DateTime.UtcNow.AddDays(1))
            };

            // Act
            var result = _validator.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().Which.ErrorMessage.Should().Be("City must be provided.");
        }

        [Test]
        public void ShouldHaveErrorWhenStartRentDateIsNotProvided()
        {
            // Arrange
            var request = new CarsRequest
            {
                Country = "USA",
                City = "New York",
                To = Timestamp.FromDateTime(DateTime.UtcNow.AddDays(1))
        };

            // Act
            var result = _validator.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().Which.ErrorMessage.Should().Be("Start rent date must be provided.");
        }

        [Test]
        public void ShouldHaveErrorWhenCompliteRentDateIsNotProvided()
        {
            // Arrange
            var request = new CarsRequest
            {
                Country = "USA",
                City = "New York",
                From = Timestamp.FromDateTime(DateTime.UtcNow)
            };

            // Act
            var result = _validator.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().Which.ErrorMessage.Should().Be("Complite rent date must be provided.");
        }

        [Test]
        public void ShouldHaveErrorWhenStartRentDateIsInThePast()
        {
            // Arrange
            var request = new CarsRequest
            {
                Country = "USA",
                City = "New York",
                From = Timestamp.FromDateTime(DateTime.UtcNow.AddDays(-1)),
                To = Timestamp.FromDateTime(DateTime.UtcNow.AddDays(1))
            };

            // Act
            var result = _validator.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().Which.ErrorMessage.Should().Be("Start rent date must be in the future or today.");
        }

        [Test]
        public void ShouldHaveErrorWhenCompliteRentDateIsInThePast()
        {
            // Arrange
            var request = new CarsRequest
            {                
                Country = "USA",
                City = "New York",
                From = Timestamp.FromDateTime(DateTime.UtcNow),
                To = Timestamp.FromDateTime(DateTime.UtcNow.AddMinutes(2)),
            };

            // Act
            var result = _validator.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().Which.ErrorMessage.Should().Be("Complite rent date must be in the future.");
        }

        [Test]
        public void ShouldHaveErrorWhenStartRentDateIsLaterThanCompliteRentDate()
        {
            // Arrange
            var request = new CarsRequest
            {
                Country = "USA",
                City = "New York",
                From =  Timestamp.FromDateTime(DateTime.UtcNow.AddDays(3)),
                To = Timestamp.FromDateTime(DateTime.UtcNow.AddDays(1)),
        };

            // Act
            var result = _validator.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().Which.ErrorMessage.Should().Be("The start rent date must be earlier than the complite rent date.");
        }
    }
}
