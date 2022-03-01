using AutoMapper;
using JwtAPI.Core.Application.Features.CQRS.Commands;
using JwtAPI.Core.Application.Features.CQRS.Queries;
using JwtAPI.Core.Application.Interfaces;
using JwtAPI.Core.Domain;
using MediatR;

namespace JwtAPI.Core.Application.Features.CQRS.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        private readonly IRepository<Product> repository;
        private readonly IMapper mapper;
        public UpdateProductCommandHandler(IRepository<Product> _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }
        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedProduct = await repository.GetByIdAsync(request.Id);
            if (updatedProduct != null)
            {
                updatedProduct.CategoryId=request.CategoryId;
                updatedProduct.Stock = request.Stock;
                updatedProduct.Price = request.Price;
                updatedProduct.Definiton = request.Definiton;
            }
            return Unit.Value;
        }
    }
}
