using CarRent.Application.Grpc;
using CarRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.Application.Interfaces
{
    public interface ICarFilterStrategy
    {
        Task<IEnumerable<Car>> FilterCarsAsync(CarsRequest request, CancellationToken cancellationToken);

        Expression<Func<Car, bool>> IsCarMatch(CarsRequest request);
    }
}
