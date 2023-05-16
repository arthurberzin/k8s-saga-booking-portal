using Airline.Application.Interfaces;
using Airline.Application.Grpc;
using AutoMapper;
using Serilog;
using Grpc.Core;
using FluentValidation;

namespace Airline.Application.GrpcService
{
    public class GrpcAirlineService : FlightsService.FlightsServiceBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IFlightFilterStrategy _filterStrategy;
        private readonly IValidator<FlightsRequest> _requestValidator;

        public GrpcAirlineService(IMapper mapper, ILogger logger, IFlightFilterStrategy filterStrategy, IValidator<FlightsRequest> requestValidator)
        {
            _mapper = mapper;
            _logger = logger;
            _filterStrategy = filterStrategy;
            _requestValidator = requestValidator;
        }

        public override async Task<FlightsResponse> GetFlights(FlightsRequest request, ServerCallContext context)
        {
            try
            {
                var validationResult = _requestValidator.Validate(request);
                if (!validationResult.IsValid)
                {
                    throw new RpcException(
                        new Status(
                            StatusCode.InvalidArgument,
                            string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage))
                            )
                        );
                }

                var response = new FlightsResponse();

                var filteredFlights = await _filterStrategy.FilterFlightsAsync(request, context.CancellationToken);

                response.Flights.AddRange(_mapper.Map<List<FlightData>>(filteredFlights.ToList()));

                return response;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                throw;
            }
        }
    }
}
