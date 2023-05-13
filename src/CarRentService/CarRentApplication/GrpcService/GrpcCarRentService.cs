using AutoMapper;
using CarRent.Application.Grpc;
using CarRent.Application.Interfaces;
using CarRent.Models;
using Grpc.Core;
using Serilog;

namespace CarRent.Application.GrpcService
{
    public  class GrpcCarRentService : CarService.CarServiceBase
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

        public override async Task<CarsResponse?> GetCars(CarsRequest request, ServerCallContext context)
        {
            try
            {
                if(string.IsNullOrEmpty(request.Location) && request.Latitude <= 0 && request.Longitude <= 0)
                {
                    _logger.Error("Bad Request");
                    return null;
                }
                Location destLocation = !string.IsNullOrEmpty(request.Location) ? _openCageDataClient.GetLocationByName(request.Location) : new Location { Latitude = request.Latitude, Longitude = request.Longitude};
            
                var response = new CarsResponse();

                var res = await _unitOfWork.Cars.GetAllAsync(context.CancellationToken);
                response.Cars.AddRange(res.ToList().Select(it => _mapper.Map<Car, CarData>(it, opt =>
                                opt.AfterMap((src, dest) => dest.Distance = _calculator.CalculateDistance(src.CurrentLocation, destLocation)))));

                return response;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return null;
            }
        }
    }
}
