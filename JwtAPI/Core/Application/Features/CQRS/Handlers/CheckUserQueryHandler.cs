using JwtAPI.Core.Application.Dto;
using JwtAPI.Core.Application.Features.CQRS.Queries;
using JwtAPI.Core.Application.Interfaces;
using JwtAPI.Core.Domain;
using MediatR;

namespace JwtAPI.Core.Application.Features.CQRS.Handlers
{
    public class CheckUserQueryHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto>
    {
        private readonly IRepository<AppRole> roleRepository;
        private readonly IRepository<AppUser> userRepository;
        public CheckUserQueryHandler(IRepository<AppRole> _roleRepository, IRepository<AppUser> _userRepository)
        {
            roleRepository = _roleRepository;
            userRepository = _userRepository;
        }
        public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = new CheckUserResponseDto();
            var user = await userRepository.GetByFilterAsync(x => x.UserName == request.UserName && x.Password == request.Password);
            if (user == null)
            {
                dto.IsExist = false;
            }
            else
            {
                dto.UserName = user.UserName;
                dto.Id = user.Id;
                dto.IsExist = true;
                var role = await roleRepository.GetByFilterAsync(x=>x.Id==user.AppRoleId);
            }
            return dto;
        }
    }
}
