﻿using MediatR;

namespace JwtAPI.Core.Application.Features.CQRS.Commands
{
    public class DeleteProductCommandRequest:IRequest
    {
        public int Id { get; set; }
        public DeleteProductCommandRequest(int id)
        {
            Id = id;
        }
    }
}
