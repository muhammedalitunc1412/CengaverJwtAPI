using AutoMapper;
using JwtAPI.Core.Application.Dto;
using JwtAPI.Core.Domain;

namespace JwtAPI.Core.Application.Mappings
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            this.CreateMap<Product,ProductListDto>().ReverseMap();
        }
    }
}
