using AutoMapper;
using JwtAPI.Core.Application.Dto;
using JwtAPI.Core.Application.Features.CQRS.Queries;
using JwtAPI.Core.Application.Interfaces;
using JwtAPI.Core.Domain;
using MediatR;

namespace JwtAPI.Core.Application.Features.CQRS.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, List<ProductListDto>>
    {
        private readonly IRepository<Product> repository;
        private readonly IMapper mapper;
        public GetAllProductsQueryHandler(IRepository<Product> _repository,IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }
        public async Task<List<ProductListDto>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var data= await repository.GetAllAsync();
            return mapper.Map<List<ProductListDto>>(data);
        }
    }
}
