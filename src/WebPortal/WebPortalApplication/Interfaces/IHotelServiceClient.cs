using WebPortal.Application.Grpc;

namespace WebPortal.Application.Interfaces
{
    public interface IHotelServiceClient
    {
        Task<IEnumerable<HotelData>> GetHotels(DateTime from, DateTime to, CancellationToken cancellationToken = default);
    }
}
