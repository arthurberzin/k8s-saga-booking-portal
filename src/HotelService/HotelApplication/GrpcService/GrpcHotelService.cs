using Ardalis.GuardClauses;
using AutoMapper;
using Grpc.Core;
using Hotel.Application.Interfaces;
using Serilog;

namespace Hotel.Application.Grpc.Service
{
    public class GrpcHotelService : HotelService.HotelServiceBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GrpcHotelService(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public override async Task<HotelsResponse> GetHotels(HotelsRequest request, ServerCallContext context)
        {
            try
            {
                Guard.Against.Null(request, nameof(request));
                Guard.Against.NullOrWhiteSpace(request.Country, nameof(request.Country));
                Guard.Against.NullOrWhiteSpace(request.City, nameof(request.City));

                Guard.Against.InvalidInput(request.From, "Start Rent Date", From =>  From.ToDateTime() >= DateTime.UtcNow);
                Guard.Against.InvalidInput(request.To, "Complite Rent Date", to => to.ToDateTime() >= DateTime.UtcNow);
                Guard.Against.InvalidInput(request, "Date Range", req => req.From < req.To, "The start rent date must be earlier than the complite rent date.");

                var response = new HotelsResponse();
                var res = await _unitOfWork.Hotels.FindAsync(
                    it => it.City.ToLower() == request.City.ToLower() &&
                    it.Country.ToLower() == request.Country.ToLower() && 
                    !it.OccupiedDates.Any(dt => request.From.ToDateTime() <= dt.OccupateDate && dt.OccupateDate <= request.To.ToDateTime()), 
                    context.CancellationToken);

                response.Hotels.AddRange(_mapper.Map<List<HotelData>>(res.ToList()));

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
