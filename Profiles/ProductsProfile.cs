using AutoMapper;
using ShopsRCUS.Discount.API.Entities.DTOs;
using ShopsRCUS.Discount.API.Models;

namespace ShopsRCUS.Discount.API.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<ProductDTO, Product>()
                .ForMember(
                    dest => dest.TotalPrice,
                    opt => opt.MapFrom(src => src.Price * src.Quantity));


            CreateMap<ProductCreationDTO, Product>()
                    .ForMember(
                        dest => dest.TotalPrice,
                        opt => opt.MapFrom(src => src.Price * src.Quantity))
                    .ForMember(
                        dest => dest.UnitPrice,
                        opt => opt.MapFrom(src => src.Price));

           
        }
    }
}
