using FluentValidation;
using Grpc.Core.Interceptors;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRent.Application.Grpc;
using CarRent.Application.Interfaces;
using Serilog;

namespace CarRent.Application.GrpcService
{
    public  class LocationValidationInterceptor : Interceptor
    {

        private readonly IOpenCageDataClient _openCageDataClient;
        private readonly ILogger _logger;

        public LocationValidationInterceptor(IOpenCageDataClient openCageDataClient, ILogger logger)
        {
            _openCageDataClient = openCageDataClient;
            _logger = logger;
        }

        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {

            var req = request as CarsRequest;
            if (req is null)
            {
                string message = "Request is empty.";
                _logger.Error(message);
                throw new RpcException(new Status(StatusCode.InvalidArgument, message));
            }

            if (req.Latitude == 0 || req.Longitude == 0)
            {
                if (string.IsNullOrEmpty(req.Location) is false)
                {
                    (req.Latitude, req.Longitude) = _openCageDataClient.GetLocationByName(req.Location);
                }
                else if (string.IsNullOrEmpty(req.Country) is false && string.IsNullOrEmpty(req.City) is false)
                {
                    (req.Latitude, req.Longitude) = _openCageDataClient.GetLocationByName($"{req.Country}, {req.City}");
                }
            }

            if (req.Latitude == 0 || req.Longitude == 0)
            {
                var message = $"Invalid input parameters. location: '{req.Location}', Latitude: '{req.Latitude}', Longitude: '{req.Longitude}', Country: '{req.Country}', City: '{req.City}' ";
                _logger.Error(message);
                throw new RpcException(new Status(StatusCode.InvalidArgument, message));
            }

            return await continuation(request, context);
        }
    }
}
