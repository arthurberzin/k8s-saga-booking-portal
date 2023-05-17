using FluentValidation;
using Grpc.Core.Interceptors;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRent.Application.Grpc;
using Serilog;

namespace CarRent.Application.GrpcService
{
    public class FluentValidationInterceptor : Interceptor
    {
        private readonly IValidator<CarsRequest> _validator;
        private readonly ILogger _logger;

        public FluentValidationInterceptor(IValidator<CarsRequest> validator, ILogger logger)
        {
            _validator = validator;
            _logger = logger;
        }

        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            // Perform validation
            var req = request as CarsRequest;
            if (req is null) 
            {
                string message = "Request is empty.";
                _logger.Error(message);
                throw new RpcException(new Status(StatusCode.InvalidArgument, message));
            } 
            var validationResult = await _validator.ValidateAsync(req);

            if (!validationResult.IsValid)
            {
                string message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                _logger.Error(message);
                throw new RpcException( new Status( StatusCode.InvalidArgument, message ) );
            }

            // Validation successful, proceed with the request handling
            return await continuation(request, context);
        }
    }
}
