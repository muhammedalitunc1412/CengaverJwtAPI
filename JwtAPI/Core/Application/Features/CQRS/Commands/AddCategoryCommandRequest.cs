using MediatR;

namespace JwtAPI.Core.Application.Features.CQRS.Commands
{
    public class AddCategoryCommandRequest:IRequest
    {
        public string? Definition { get; set; }
    }
}
