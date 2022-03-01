using JwtAPI.Core.Application.Features.CQRS.Commands;
using JwtAPI.Core.Application.Interfaces;
using JwtAPI.Core.Domain;
using MediatR;

namespace JwtAPI.Core.Application.Features.CQRS.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
    {
        private readonly IRepository<Product> repository;
        public CreateProductCommandHandler(IRepository<Product> _repository)
        {
            repository = _repository;
        }
        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            repository.CreateAsync(new Product
            {
                CategoryId = request.CategoryId,
                Definiton = request.Definiton,
                Price = request.Price,
                Stock = request.Stock,
            });
            return Unit.Value;
        }
    }
}
