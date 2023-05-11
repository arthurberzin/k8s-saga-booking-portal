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

        public override async Task<HotelsResponse?> GetHotels(HotelsRequest request, ServerCallContext context)
        {
            try
            {
                var response = new HotelsResponse();

                var res = await _unitOfWork.Hotels.GetAllAsync(context.CancellationToken);
                response.Hotels.AddRange(_mapper.Map<List<HotelData>>(res.ToList()));

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
