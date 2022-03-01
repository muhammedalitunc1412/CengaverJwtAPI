using JwtAPI.Core.Application.Features.CQRS.Commands;
using JwtAPI.Core.Application.Interfaces;
using JwtAPI.Core.Domain;
using MediatR;

namespace JwtAPI.Core.Application.Features.CQRS.Handlers
{
    public class DeleteCategoryCommandHandler:IRequestHandler<DeleteCategoryCommandRequest>
    {
        private readonly IRepository<Category> repository;
        public DeleteCategoryCommandHandler(IRepository<Category> _repository)
        {
            repository= _repository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity=await repository.GetByIdAsync(request.Id);
            if (deletedEntity != null)
                await repository.RemoveAsync(deletedEntity);
            return Unit.Value;
        }
    }
}
