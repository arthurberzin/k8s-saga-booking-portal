using FluentAssertions;
using Google.Protobuf.WellKnownTypes;
using Hotel.Application.Grpc;
using Hotel.Application.Validation;

namespace HotelApplicationTests
{
    [TestFixture]
    public class HotelRequestValidatorTests
    {
        private HotelRequestValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new HotelRequestValidator();
        }

        [Test]
        public void ShouldHaveErrorWhenCountryIsNotProvided()
        {
            // Arrange
            var request = new HotelsRequest
            {
                // Set other properties as needed
                City = "New York",
                From = Timestamp.FromDateTime(DateTime.UtcNow.AddMinutes(1)),
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
            var request = new HotelsRequest
            {
                // Set other properties as needed
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
        public void ShouldHaveErrorWhenArrivalDateIsNotProvided()
        {
            // Arrange
            var request = new HotelsRequest
            {
                // Set other properties as needed
                Country = "USA",
                City = "New York",
                To = Timestamp.FromDateTime(DateTime.UtcNow.AddDays(1))
            };

            // Act
            var result = _validator.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().Which.ErrorMessage.Should().Be("Arrival date must be provided.");
        }

        [Test]
        public void ShouldHaveErrorWhenDepartureDateIsNotProvided()
        {
            // Arrange
            var request = new HotelsRequest
            {
                // Set other properties as needed
                Country = "USA",
                City = "New York",
                From = Timestamp.FromDateTime(DateTime.UtcNow),
        };

            // Act
            var result = _validator.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().Which.ErrorMessage.Should().Be("Departure date must be provided.");
        }

        [Test]
        public void ShouldHaveErrorWhenArrivalDateIsInThePast()
        {
            // Arrange
            var request = new HotelsRequest
            {
                // Set other properties as needed
                Country = "USA",
                City = "New York",
                From = Timestamp.FromDateTime(DateTime.UtcNow.AddDays(-1)),
                To = Timestamp.FromDateTime(DateTime.UtcNow.AddDays(2))
            };

            // Act
            var result = _validator.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().Which.ErrorMessage.Should().Be("Arrival date must be in the future or today.");
        }

        [Test]
        public void ShouldHaveErrorWhenDepartureDateIsNotInTheFuture()
        {
            // Arrange
            var request = new HotelsRequest
            {
                // Set other properties as needed
                Country = "USA",
                City = "New York",
                From = Timestamp.FromDateTime(DateTime.UtcNow),
                To = Timestamp.FromDateTime(DateTime.UtcNow)
            };

            // Act
            var result = _validator.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().Which.ErrorMessage.Should().Be("Departure date must be in the future.");
        }

        [Test]
        public void ShouldHaveErrorWhenDepartureDateIsLaterThanArrivalDate()
        {
            // Arrange
            var request = new HotelsRequest
            {
                // Set other properties as needed
                Country = "USA",
                City = "New York",
                From = Timestamp.FromDateTime(DateTime.UtcNow.AddDays(3)),
                To = Timestamp.FromDateTime(DateTime.UtcNow.AddDays(1))
            };

            // Act
            var result = _validator.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().Which.ErrorMessage.Should().Be("The departure date must be earlier than the arrival date.");
        }
    }

}