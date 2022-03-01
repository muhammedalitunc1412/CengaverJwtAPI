using JwtAPI.Core.Application.Features.CQRS.Commands;
using JwtAPI.Core.Application.Interfaces;
using JwtAPI.Core.Domain;
using MediatR;

namespace JwtAPI.Core.Application.Features.CQRS.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest>
    {
        private readonly IRepository<Category> repository;
        public UpdateCategoryCommandHandler(IRepository<Category> _repository)
        {
            repository = _repository;
        }
        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
           var updatedEntity=await repository.GetByIdAsync(request.Id);
            if (updatedEntity != null)
            updatedEntity.Definiton = request.Definition;
            await repository.UpdateAsync(updatedEntity);
            return Unit.Value;
        }
    }
}
