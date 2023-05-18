using AppplicationTests.Helpers;
using CarRent.Application.Grpc;
using CarRent.Application.GrpcService;
using CarRent.Application.Interfaces;
using FluentAssertions;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Moq;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppplicationTests
{
    internal class LocationValidationInterceptorTests
    {
        private LocationValidationInterceptor _interceptor;
        private Mock<IOpenCageDataClient> _openCageDataClientMock;
        private Mock<ILogger> _loggerMock;

        [SetUp]
        public void Setup()
        {
            _openCageDataClientMock = new Mock<IOpenCageDataClient>();
            _openCageDataClientMock.Setup(x => x.GetLocationByName(It.Is<string>(inp => inp == "Location"))).Returns((12.0, 14.0));
            _openCageDataClientMock.Setup(x => x.GetLocationByName(It.Is<string>(inp => inp == "Country, City"))).Returns((17.0, 19.0));

            _loggerMock = new Mock<ILogger>();
            _interceptor = new LocationValidationInterceptor(_openCageDataClientMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task UnaryServerHandler_WithValidRequest_ShouldReturnResult()
        {
            double latitude = 10.0;
            double longitude = 20.0;
            // Arrange
            var request = new CarsRequest
            {
                Latitude = latitude,
                Longitude = longitude
            };
            ServerCallContext context = (ServerCallContext)MockServerCallContext.Create();
            var continuationMock = new Mock<UnaryServerMethod<CarsRequest, Empty>>();

            // Act
            var result = await _interceptor.UnaryServerHandler(request, context, continuationMock.Object);

            // Assert
            request.Latitude.Should().Be(latitude);
            request.Longitude.Should().Be(longitude);
            continuationMock.Verify(continuation => continuation(request, context), Times.Once);
        }

        [Test]
        public async Task UnaryServerHandler_WithValidRequest_Location_ShouldReturnResult()
        {

            // Arrange
            var request = new CarsRequest
            {
                Latitude = 0,
                Longitude = 0,
                Location = "Location",
            };
            ServerCallContext context = (ServerCallContext)MockServerCallContext.Create();
            var continuationMock = new Mock<UnaryServerMethod<CarsRequest, Empty>>();

            // Act
            var result = await _interceptor.UnaryServerHandler(request, context, continuationMock.Object);

            // Assert
            request.Latitude.Should().Be(12.0);
            request.Longitude.Should().Be(14.0);
            continuationMock.Verify(continuation => continuation(request, context), Times.Once);
        }

        [Test]
        public async Task UnaryServerHandler_WithValidRequest_CountryAndCity_ShouldReturnResult()
        {

            // Arrange
            var request = new CarsRequest
            {
                Latitude = 0,
                Longitude = 0,
                Country = "Country",
                City = "City"
            };
            ServerCallContext context = (ServerCallContext)MockServerCallContext.Create();
            var continuationMock = new Mock<UnaryServerMethod<CarsRequest, Empty>>();

            // Act
            var result = await _interceptor.UnaryServerHandler(request, context, continuationMock.Object);

            // Assert
            request.Latitude.Should().Be(17.0);
            request.Longitude.Should().Be(19.0);
            continuationMock.Verify(continuation => continuation(request, context), Times.Once);
        }

        [Test]
        public async Task UnaryServerHandler_WithEmptyRequest_ShouldNotThrowRpcException()
        {
            // Arrange
            CarsRequest request = null;
            ServerCallContext context = (ServerCallContext)MockServerCallContext.Create();
            var continuationMock = new Mock<UnaryServerMethod<CarsRequest, Empty>>();

            // Act
            Func<Task> act = async () =>
            {
                await _interceptor.UnaryServerHandler(request, context, continuationMock.Object);
            };

            // Assert
            act.Should().NotThrowAsync<RpcException>();

            continuationMock.Verify(continuation => continuation(request, context), Times.Once);
        }

        [Test]
        public async Task UnaryServerHandler_WithEmptyRequest_ShouldThrowRpcException()
        {
            // Arrange
            ServerCallContext context = (ServerCallContext)MockServerCallContext.Create();
            var continuationMock = new Mock<UnaryServerMethod<CarsRequest, Empty>>();

            // Arrange
            var request = new CarsRequest { };

            // Act
            Func<Task> act = async () =>
            {
                await _interceptor.UnaryServerHandler(request, context, continuationMock.Object);
            };

            // Assert
            var res = await act.Should().ThrowAsync<RpcException>();
            res.Which.Status.StatusCode.Should().Be(StatusCode.InvalidArgument);
            res.Which.Status.Detail.Should().Match("*Invalid input parameters*");

            _loggerMock.Verify(logger => logger.Error(It.IsAny<string>()), Times.Once);
            continuationMock.Verify(continuation => continuation(request, context), Times.Never);
        }

        [Test]
        public async Task UnaryServerHandler_WithInvalidInputParameters_ShouldThrowRpcException()
        {
            // Arrange
            var request = new CarsRequest();
            ServerCallContext context = (ServerCallContext)MockServerCallContext.Create();
            var continuationMock = new Mock<UnaryServerMethod<CarsRequest, Empty>>();
            _loggerMock.Setup(logger => logger.Error(It.IsAny<string>()));

            // Act
            Func<Task> act = async () =>
            {
                await _interceptor.UnaryServerHandler(request, context, continuationMock.Object);
            };

            // Assert
            var res = await act.Should().ThrowAsync<RpcException>();
            res.Which.Status.StatusCode.Should().Be(StatusCode.InvalidArgument);
            res.Which.Status.Detail.Should().Be("Invalid input parameters. location: '', Latitude: '0', Longitude: '0', Country: '', City: '';");

            _loggerMock.Verify(logger => logger.Error(It.IsAny<string>()), Times.Once);
            continuationMock.Verify(continuation => continuation(request, context), Times.Never);
        }

        [Test]
        public async Task UnaryServerHandler_WithValidInputParametersButNotFoundLocation_ShouldThrowRpcException()
        {
            // Arrange
            var request = new CarsRequest
            {
                Latitude = 0,
                Longitude = 0,
                Location = "BadLocationName",
            };
            ServerCallContext context = (ServerCallContext)MockServerCallContext.Create();
            var continuationMock = new Mock<UnaryServerMethod<CarsRequest, Empty>>();
            _loggerMock.Setup(logger => logger.Error(It.IsAny<string>()));

            // Act
            Func<Task> act = async () =>
            {
                await _interceptor.UnaryServerHandler(request, context, continuationMock.Object);
            };

            // Assert
            var res = await act.Should().ThrowAsync<RpcException>();
            res.Which.Status.StatusCode.Should().Be(StatusCode.InvalidArgument);
            res.Which.Status.Detail.Should().Be("Invalid input parameters. location: 'BadLocationName', Latitude: '0', Longitude: '0', Country: '', City: '';");

            _loggerMock.Verify(logger => logger.Error(It.IsAny<string>()), Times.Once);
            continuationMock.Verify(continuation => continuation(request, context), Times.Never);
        }
    }
}
