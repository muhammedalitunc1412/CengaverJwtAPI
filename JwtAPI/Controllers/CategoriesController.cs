using JwtAPI.Core.Application.Features.CQRS.Commands;
using JwtAPI.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAPI.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Member")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator mediator;
        public CategoriesController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await mediator.Send(new GetCategoriesQueryRequest());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var result = await mediator.Send(new GetCategoryQueryRequest(id));
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddCategoryCommandRequest request)
        {
            var result = await mediator.Send(request);
            return Created("", request);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryCommandRequest request)
        {
            await mediator.Send(request);
            return NoContent();
        }
        [HttpDelete("{id}")]    
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new DeleteCategoryCommandRequest(id));
            return NoContent() ;
        }
    }
}
