using AutoMapper;

namespace ShopsRCUS.Discount.API.Services.Implementations
{
    public class AutoMapperInstanceTesting
    {
        private readonly IMapper _mapper;
        public AutoMapperInstanceTesting(IMapper mapper)
        {
            _mapper = mapper;
        }



        public  IMapper Mapper => _mapper;
    }
}
