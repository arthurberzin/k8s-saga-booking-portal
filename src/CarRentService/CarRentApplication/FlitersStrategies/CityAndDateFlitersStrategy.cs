using CarRent.Application.Grpc;
using CarRent.Application.Interfaces;
using CarRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.Application.FlitersStrategies
{
    public class CityAndDateFlitersStrategy : ICarFilterStrategy
    {
        private readonly IUnitOfWork _unitOfWork;

        public CityAndDateFlitersStrategy(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Car>> FilterCarsAsync(CarsRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Cars.FindAsync(IsCarMatch(request), cancellationToken);
        }

        public Expression<Func<Car, bool>> IsCarMatch(CarsRequest request)
        {
            return car => car.CurrentLocation.Country.ToLower() == request.Country.ToLower() &&
                          car.CurrentLocation.City.ToLower() == request.City.ToLower() &&
                         !car.OccupiedDates.Any(
                             dt => dt.OccupateDate >= request.From.ToDateTime() &&
                                   dt.OccupateDate <= request.To.ToDateTime());
        }
    }
}
