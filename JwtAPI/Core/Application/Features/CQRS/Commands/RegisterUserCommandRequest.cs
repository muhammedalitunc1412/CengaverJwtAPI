﻿using MediatR;

namespace JwtAPI.Core.Application.Features.CQRS.Commands
{
    public class RegisterUserCommandRequest:IRequest
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
