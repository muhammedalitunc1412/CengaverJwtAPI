using JwtAPI.Core.Application.Features.CQRS.Commands;
using JwtAPI.Core.Application.Interfaces;
using JwtAPI.Core.Domain;
using MediatR;

namespace JwtAPI.Core.Application.Features.CQRS.Handlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<AddCategoryCommandRequest>
    {
        private readonly IRepository<Category> repository;
        public CreateCategoryCommandHandler(IRepository<Category> _repository)
        {
            repository = _repository;
        }
        public async Task<Unit> Handle(AddCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new Category
            {
                Definiton=request.Definition
            });
            return Unit.Value;
        }
    }
}
