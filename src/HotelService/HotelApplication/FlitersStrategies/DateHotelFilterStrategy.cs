using Hotel.Application.Grpc;
using Hotel.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.FlitersStrategies
{
    public class DateHotelFilterStrategy : IHotelFilterStrategy
    {
        private readonly IUnitOfWork _unitOfWork;

        public DateHotelFilterStrategy(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Models.Hotel>> FilterHotelsAsync(HotelsRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Hotels.FindAsync(IsHotelMatch(request), cancellationToken);
        }

        public Expression<Func<Models.Hotel, bool>> IsHotelMatch(HotelsRequest request)
        {
            return  hotel => hotel.City.ToLower() == request.City.ToLower() &&
                        hotel.Country.ToLower() == request.Country.ToLower() &&
                        !hotel.OccupiedDates.Any(
                            dt =>   dt.OccupateDate.Date >= request.From.ToDateTime().Date && 
                                    dt.OccupateDate.Date <= request.To.ToDateTime().Date);
        }
    }
}
