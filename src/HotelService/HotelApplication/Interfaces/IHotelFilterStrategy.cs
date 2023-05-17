using Hotel.Application.Grpc;
using Hotel.Models;
using System.Linq.Expressions;

namespace Hotel.Application.Interfaces
{
    public interface IHotelFilterStrategy
    {
        Task<IEnumerable<Models.Hotel>> FilterHotelsAsync(HotelsRequest request, CancellationToken cancellationToken);

        Expression<Func<Models.Hotel, bool>> IsHotelMatch(HotelsRequest request);
    }
}
