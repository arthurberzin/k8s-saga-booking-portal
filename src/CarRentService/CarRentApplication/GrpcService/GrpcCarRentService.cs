using AutoMapper;
using CarRent.Application.Grpc;
using CarRent.Application.Interfaces;
using CarRent.Models;
using FluentValidation;
using Grpc.Core;
using Serilog;

namespace CarRent.Application.GrpcService
{
    public class GrpcCarRentService : CarService.CarServiceBase
    {
        private readonly IDistanceCalculator _calculator;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ICarFilterStrategy _carFilterStrategy;

        public GrpcCarRentService(IDistanceCalculator calculator, 
            IOpenCageDataClient openCageDataClient, 
            IMapper mapper, 
            ILogger logger, 
            ICarFilterStrategy carFilterStrategy)
        {
            _mapper = mapper;
            _logger = logger;
            _calculator = calculator;
            _carFilterStrategy = carFilterStrategy;
        }

        public override async Task<CarsResponse> GetCars(CarsRequest request, ServerCallContext context)
        {
            try
            {
                var response = new CarsResponse();
                var filteredCars = await _carFilterStrategy.FilterCarsAsync(request, context.CancellationToken);

                response.Cars.AddRange(
                    filteredCars.ToList().Select(
                        it => _mapper.Map<Car, CarData>( it, 
                        opt => opt.AfterMap( 
                            (src, dest) => dest.Distance = _calculator.CalculateDistance(src.CurrentLocation.Latitude, src.CurrentLocation.Longitude, request.Latitude, request.Longitude)))));

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
