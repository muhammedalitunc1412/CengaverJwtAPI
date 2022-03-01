using AutoMapper;
using JwtAPI.Core.Application.Dto;
using JwtAPI.Core.Application.Features.CQRS.Queries;
using JwtAPI.Core.Application.Interfaces;
using JwtAPI.Core.Domain;
using MediatR;

namespace JwtAPI.Core.Application.Features.CQRS.Handlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQueryRequest, ProductListDto>
    {
        private readonly IRepository<Product> repository;
        private readonly IMapper mapper;
        public GetProductQueryHandler(IRepository<Product> _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }
        public async Task<ProductListDto> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
        {
            var data= await repository.GetByFilterAsync(x => x.Id == request.Id);
            return mapper.Map<ProductListDto>(data);
        }
    }
}
