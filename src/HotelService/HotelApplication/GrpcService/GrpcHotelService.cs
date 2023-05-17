
using AutoMapper;
using FluentValidation;
using Grpc.Core;
using Hotel.Application.Interfaces;
using Serilog;

namespace Hotel.Application.Grpc.Service
{
    public class GrpcHotelService : HotelService.HotelServiceBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IHotelFilterStrategy _filterStrategy;
        private readonly IValidator<HotelsRequest> _validator;

        public GrpcHotelService(
            IHotelFilterStrategy filterStrategy,
            IValidator<HotelsRequest> validator,
            IMapper mapper, 
            ILogger logger)
        {
            _filterStrategy = filterStrategy;
            _validator = validator;
            _mapper = mapper;
            _logger = logger;
        }

        public override async Task<HotelsResponse> GetHotels(HotelsRequest request,  ServerCallContext context)
        {
            try
            {

                var validationResult = _validator.Validate(request);
                if (!validationResult.IsValid)
                {
                    throw new RpcException(
                        new Status(
                            StatusCode.InvalidArgument,
                            string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage))
                            )
                        );
                }

                var response = new HotelsResponse();

                var filteredHotels = await _filterStrategy.FilterHotelsAsync(request, context.CancellationToken);

                response.Hotels.AddRange(_mapper.Map<List<HotelData>>(filteredHotels.ToList()));

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
