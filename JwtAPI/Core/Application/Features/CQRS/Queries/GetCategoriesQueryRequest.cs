using JwtAPI.Core.Application.Dto;
using MediatR;

namespace JwtAPI.Core.Application.Features.CQRS.Queries
{
    public class GetCategoriesQueryRequest:IRequest<List<CategoryListDto>>
    {
    }
}
