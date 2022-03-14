using ShopsRCUS.Discount.API.Entities.DTOs;
using AutoMapper;

namespace ShopsRCUS.Discount.API.Profiles
{
    public class DiscountsProfile : Profile
    {
        public DiscountsProfile()
        {

            CreateMap<DiscountCreationDTO,ShopsRCUS.Discount.API.Models.Discount>();

            CreateMap<ShopsRCUS.Discount.API.Models.Discount, DiscountCreationDTO>();

            CreateMap<DiscountDTO, ShopsRCUS.Discount.API.Models.Discount>();

            CreateMap<ShopsRCUS.Discount.API.Models.Discount, DiscountDTO>();
        }
    }
}
