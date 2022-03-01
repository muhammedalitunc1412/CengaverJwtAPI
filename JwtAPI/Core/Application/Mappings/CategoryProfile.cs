using AutoMapper;
using JwtAPI.Core.Application.Dto;
using JwtAPI.Core.Domain;

namespace JwtAPI.Core.Application.Mappings
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category,CategoryListDto>().ReverseMap();
        }
    }
}
