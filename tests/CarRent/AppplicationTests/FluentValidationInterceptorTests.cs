using AppplicationTests.Helpers;
using CarRent.Application.Grpc;
using CarRent.Application.GrpcService;
using FluentAssertions;
using FluentValidation;
using Grpc.Core;
using Moq;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppplicationTests
{
    internal class FluentValidationInterceptorTests
    {
        private FluentValidationInterceptor _interceptor;
        private Mock<IValidator<CarsRequest>> _validatorMock;
        private Mock<ILogger> _loggerMock;

        [SetUp]
        public void Setup()
        {
            _validatorMock = new Mock<IValidator<CarsRequest>>();
            _loggerMock = new Mock<ILogger>();
            _interceptor = new FluentValidationInterceptor(_validatorMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task UnaryServerHandler_WithValidRequest_ShouldReturnResponse()
        {
            // Arrange
            var request = new CarsRequest();
            ServerCallContext context = (ServerCallContext)MockServerCallContext.Create();

            var expectedResult = new CarsResponse();

            var continuationMock = new Mock<UnaryServerMethod<CarsRequest, CarsResponse>>();
            continuationMock.Setup(c => c(request, context)).ReturnsAsync(expectedResult);

            _validatorMock.Setup(v => v.ValidateAsync(request, default)).ReturnsAsync(new FluentValidation.Results.ValidationResult());

            // Act
            var result = await _interceptor.UnaryServerHandler(request, context, continuationMock.Object);

            // Assert
            result.Should().Be(expectedResult);
            continuationMock.Verify(c => c(request, context), Times.Once);
        }

        [Test]
        public async Task UnaryServerHandler_WithEmptyRequest_ShouldThrowRpcException()
        {
            // Arrange
            CarsRequest request = null;
            ServerCallContext context = (ServerCallContext)MockServerCallContext.Create();

            _loggerMock.Setup(l => l.Error(It.IsAny<string>()));

            var expectedResult = new CarsResponse();
            var continuationMock = new Mock<UnaryServerMethod<CarsRequest, CarsResponse>>();
            continuationMock.Setup(c => c(request, context)).ReturnsAsync(expectedResult);

            // Act & Assert
            Func<Task> act = async () =>
            {
                await _interceptor.UnaryServerHandler(request, context, continuationMock.Object);
            };

            var res = await act.Should().ThrowAsync<RpcException>();
            res.Which.Status.StatusCode.Should().Be(StatusCode.InvalidArgument);
            res.Which.Status.Detail.Should().Be("Request is empty.");

            _loggerMock.Verify(l => l.Error(It.IsAny<string>()), Times.Once);
            continuationMock.Verify(c => c(request, context), Times.Never);
        }

        [Test]
        public async Task UnaryServerHandler_WithInvalidRequest_ShouldThrowRpcException()
        {
            // Arrange
            var request = new CarsRequest();
            ServerCallContext context = (ServerCallContext)MockServerCallContext.Create();

            var validationResult = new FluentValidation.Results.ValidationResult();
            validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure("Property1", "Error 1"));
            validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure("Property2", "Error 2"));

            var expectedResult = new CarsResponse();
            var continuationMock = new Mock<UnaryServerMethod<CarsRequest, CarsResponse>>();
            continuationMock.Setup(c => c(request, context)).ReturnsAsync(expectedResult);

            _loggerMock.Setup(l => l.Error(It.IsAny<string>()));

            _validatorMock.Setup(v => v.ValidateAsync(request, default)).ReturnsAsync(validationResult);

            // Act & Assert

            Func<Task> act = async () =>
            {
                await _interceptor.UnaryServerHandler(request, context, continuationMock.Object);
            };

            var res = await act.Should().ThrowAsync<RpcException>();

            res.Which.Status.StatusCode.Should().Be(StatusCode.InvalidArgument);
            res.Which.Status.Detail.Should().Be("Error 1, Error 2");

            _loggerMock.Verify(l => l.Error(It.IsAny<string>()), Times.Once);

            continuationMock.Verify(c => c(request, context), Times.Never);
        }
    }
}
