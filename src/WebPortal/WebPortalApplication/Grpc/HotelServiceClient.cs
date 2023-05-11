using WebPortal.Application.Interfaces;
using WebPortal.Models;
using Grpc.Net.Client;
using Microsoft.Extensions.Options;
using Serilog;

namespace WebPortal.Application.Grpc
{
    public class HotelServiceClient : IHotelServiceClient
    {
        private IOptions<WebPortalOptions> _options;
        private readonly ILogger _logger;
        public HotelServiceClient(IOptions<WebPortalOptions> options, ILogger logger) 
        {
            _options = options;
            _logger = logger;
        }
        public async Task<IEnumerable<HotelData>> GetHotels(DateTime from, DateTime to, CancellationToken cancellationToken = default)
        {
            try
            {
                var channel = GrpcChannel.ForAddress(_options.Value.HotelServiceUrl);
                var client = new HotelService.HotelServiceClient(channel);
                var request = new HotelsRequest
                {
                    From = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(from),
                    To = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(to)
                };

                var reply = await client.GetHotelsAsync(request, cancellationToken: cancellationToken);
                return reply.Hotels;
            }
            catch(Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return Enumerable.Empty<HotelData>();
            }
        }
    }
}
