using AutoMapper;
using ShopsRCUS.Discount.API.Entities.DTOs;
using ShopsRCUS.Discount.API.Models;

namespace ShopsRCUS.Discount.API.Profiles
{
    public class CustomersProfile : Profile
    {
        public CustomersProfile()
        {
            CreateMap<Customer, CustomerDTO>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));


            CreateMap<CustomerCreationDTO, Customer>()
                .ForMember(
                    dest => dest.FirstName,
                    opt => opt.MapFrom(src => src.Name.Trim().Substring(0, src.Name.Trim().IndexOf(" "))))
                .ForMember(
                    dest => dest.LastName,
                    opt => opt.MapFrom(src => src.Name.Trim().Substring(src.Name.Trim().IndexOf(" ") + 1)));
        }
    }
}
