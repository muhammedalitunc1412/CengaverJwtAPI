using AutoMapper;
using JwtAPI.Core.Application.Dto;
using JwtAPI.Core.Application.Features.CQRS.Queries;
using JwtAPI.Core.Application.Interfaces;
using JwtAPI.Core.Domain;
using MediatR;

namespace JwtAPI.Core.Application.Features.CQRS.Handlers
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryRequest, CategoryListDto>
    {
        private readonly IRepository<Category> repository;
        private readonly IMapper mapper;
        public GetCategoryQueryHandler(IRepository<Category> _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;   
        }
        public async Task<CategoryListDto> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByFilterAsync(x => x.Id == request.Id);
            return mapper.Map<CategoryListDto>(data);
        }
    }
}
