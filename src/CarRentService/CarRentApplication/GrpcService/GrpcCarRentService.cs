using Ardalis.GuardClauses;
using AutoMapper;
using CarRent.Application.Grpc;
using CarRent.Application.Interfaces;
using CarRent.Models;
using Grpc.Core;
using Serilog;

namespace CarRent.Application.GrpcService
{
    public class GrpcCarRentService : CarService.CarServiceBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDistanceCalculator _calculator;
        private readonly IOpenCageDataClient _openCageDataClient;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GrpcCarRentService(IUnitOfWork unitOfWork, IDistanceCalculator calculator, IOpenCageDataClient openCageDataClient, IMapper mapper, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _calculator = calculator;
            _openCageDataClient = openCageDataClient;
        }

        public override async Task<CarsResponse> GetCars(CarsRequest request, ServerCallContext context)
        {
            try
            {
                Guard.Against.Null(request, nameof(request));
                Guard.Against.NullOrWhiteSpace(request.Country, nameof(request.Country));
                Guard.Against.NullOrWhiteSpace(request.City, nameof(request.City));

                Guard.Against.InvalidInput(request.From, "Start Rent Date", From => From.ToDateTime() >= DateTime.UtcNow);
                Guard.Against.InvalidInput(request.To, "Complite Rent Date", to => to.ToDateTime() >= DateTime.UtcNow);
                Guard.Against.InvalidInput(request, "Date Range", req => req.From < req.To, "The start rent date must be earlier than the complite rent date.");

                double latitude = 0;
                double longitude = 0;
                if (string.IsNullOrEmpty(request.Location) is false)
                {
                    (latitude, longitude) = _openCageDataClient.GetLocationByName(request.Location);
                }
                else if (request.Latitude != 0 && request.Longitude != 0)
                {
                    latitude = request.Latitude;
                    longitude = request.Longitude;
                }
                else if (string.IsNullOrEmpty(request.Country) is false && string.IsNullOrEmpty(request.City) is false)
                {
                    (latitude, longitude) = _openCageDataClient.GetLocationByName($"{request.Country}, {request.City}");
                }
                else
                {
                    _logger.Error($"Invalid input parameters. location: '{request.Location}', Latitude: '{request.Latitude}', Longitude: '{request.Longitude}', Country: '{request.Country}', City: '{request.City}' ");
                    throw new ArgumentException("Invalid input parameters.");
                }

                var response = new CarsResponse();
                var res = await _unitOfWork.Cars.FindAsync(
                    it => it.CurrentLocation.Country.ToLower() == request.Country.ToLower() &&
                    it.CurrentLocation.City.ToLower() == request.City.ToLower() &&
                    !it.OccupiedDates.Any(dt => request.From.ToDateTime() <= dt.OccupateDate && dt.OccupateDate <= request.To.ToDateTime()),
                    context.CancellationToken);

                response.Cars.AddRange(
                    res.ToList().Select(
                        it => _mapper.Map<Car, CarData>( it, 
                        opt => opt.AfterMap( 
                            (src, dest) => dest.Distance = _calculator.CalculateDistance(src.CurrentLocation.Latitude, src.CurrentLocation.Longitude, latitude, longitude)))));

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
