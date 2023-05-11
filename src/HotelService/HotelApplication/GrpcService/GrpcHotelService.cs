using AutoMapper;
using Grpc.Core;
using Hotel.Application.Interfaces;

namespace Hotel.Application.Grpc.Service
{
    public class GrpcHotelService : HotelService.HotelServiceBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GrpcHotelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public override async Task<HotelsResponse> GetHotels(HotelsRequest request, ServerCallContext context)
        {
            var response = new HotelsResponse();            

            var res = await _unitOfWork.Hotels.GetAllAsync(context.CancellationToken);
            response.Hotels.AddRange(_mapper.Map<List<HotelData>>(res.ToList()));

            return response;
        }
    }
}
