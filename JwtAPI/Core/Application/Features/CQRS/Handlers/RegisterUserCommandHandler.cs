using JwtAPI.Core.Application.Enums;
using JwtAPI.Core.Application.Features.CQRS.Commands;
using JwtAPI.Core.Application.Interfaces;
using JwtAPI.Core.Domain;
using MediatR;

namespace JwtAPI.Core.Application.Features.CQRS.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest>
    {
        private readonly IRepository<AppUser> repository;
        public RegisterUserCommandHandler(IRepository<AppUser> _repository)
        {
            repository = _repository;
        }

        public async Task<Unit> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new AppUser
            {
                AppRoleId=(int)RoleType.Member,
                Password=request.Password,
                UserName=request.UserName,
            });
            return Unit.Value;
        }
    }
}
