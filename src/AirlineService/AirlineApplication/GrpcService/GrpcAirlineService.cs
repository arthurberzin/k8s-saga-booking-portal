using Airline.Application.Interfaces;
using Airline.Application.Grpc;
using AutoMapper;
using Serilog;
using Grpc.Core;
using Ardalis.GuardClauses;

namespace Airline.Application.GrpcService
{
    public  class GrpcAirlineService : FlightsService.FlightsServiceBase
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GrpcAirlineService(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public override async Task<FlightsResponse> GetFlights(FlightsRequest request, ServerCallContext context)
        {
            try
            {
                Guard.Against.Null(request, nameof(request));
                Guard.Against.NullOrWhiteSpace(request.ArrivalLocation, nameof(request.ArrivalLocation));
                Guard.Against.NullOrWhiteSpace(request.DepartureLocation, nameof(request.DepartureLocation));
                Guard.Against.InvalidInput(request.To, "Arrival Date", to => to.ToDateTime() >= DateTime.UtcNow);
                Guard.Against.InvalidInput(request.From, "Departure Date", From => From.ToDateTime() >= DateTime.UtcNow);
                Guard.Against.InvalidInput(request, "Date Range", req => req.From < req.To, "The departure date must be earlier than the arrival date.");

                var response = new FlightsResponse();
                var res = await _unitOfWork.Flights.FindAsync(
                    it => it.DepartureAirport.City == request.DepartureLocation
                       && it.ArrivalAirport.City == request.ArrivalLocation
                       && it.DepartureDateTime >= request.From.ToDateTime()
                       && it.ArrivalDateTime <= request.To.ToDateTime(),
                    context.CancellationToken);

                response.Flights.AddRange(_mapper.Map<List<FlightData>>(res.ToList()));

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
