using AutoMapper;
using JwtAPI.Core.Application.Features.CQRS.Commands;
using JwtAPI.Core.Application.Interfaces;
using JwtAPI.Core.Domain;
using MediatR;

namespace JwtAPI.Core.Application.Features.CQRS.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest>
    {
        private readonly IRepository<Product> repository;
        public DeleteProductCommandHandler(IRepository<Product> _repository)
        {
            repository = _repository;
        }
        public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await repository.GetByIdAsync(request.Id);
            if (deletedEntity != null)
            {
                await repository.RemoveAsync(deletedEntity);
            }
            return Unit.Value;
        }
    }
}
