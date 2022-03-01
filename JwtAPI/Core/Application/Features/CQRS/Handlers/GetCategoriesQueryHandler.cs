using AutoMapper;
using JwtAPI.Core.Application.Dto;
using JwtAPI.Core.Application.Features.CQRS.Queries;
using JwtAPI.Core.Application.Interfaces;
using JwtAPI.Core.Domain;
using MediatR;

namespace JwtAPI.Core.Application.Features.CQRS.Handlers
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQueryRequest, List<CategoryListDto>>
    {
        private readonly IRepository<Category> repository;
        private readonly IMapper mapper;
        public GetCategoriesQueryHandler(IRepository<Category> _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;

        }
        public async Task<List<CategoryListDto>> Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var data= await repository.GetAllAsync();
            return mapper.Map<List<CategoryListDto>>(data);
        }
    }
}
