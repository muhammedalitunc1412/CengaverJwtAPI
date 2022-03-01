using JwtAPI.Core.Application.Dto;
using MediatR;

namespace JwtAPI.Core.Application.Features.CQRS.Queries
{
    public class CheckUserQueryRequest:IRequest<CheckUserResponseDto>
    {
        public CheckUserQueryRequest(string userName ,string password)
        {
            UserName = userName;
            Password = password;
        }
        public string UserName { get; set; }=string.Empty;
        public string Password { get; set; }=string.Empty;
    }
}
