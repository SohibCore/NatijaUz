using MediatR;
using Microsoft.AspNetCore.Mvc;
using NatijaUz.Application.Services.TestService.Commands.Create;
using NatijaUz.Application.Services.TestService.Commands.Delete;
using NatijaUz.Application.Services.TestService.Commands.Update;
using NatijaUz.Application.Services.TestService.Dtos;
using NatijaUz.Application.Services.TestService.Queries.GetById;
using NatijaUz.Application.Services.TestService.Queries.GetList;

namespace NatijaUz.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TestController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        public async Task<ActionResult> GetList([FromQuery] TestFilterDto filter, CancellationToken cancellation)
        {
            var result = await _mediator.Send(new GetListQuery(filter), cancellation);

            if (result is null || result.Count() == 0)
                return NotFound("Hech qanday test topilmadi");

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("{Id}")]
        public async Task<ActionResult> Get([FromRoute] long Id, CancellationToken cancellation)
        {
            var result = await _mediator.Send(new GetByIdQuery(Id), cancellation);

            if (result is null)
                return NotFound("Test topilmadi");

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateTestDto dto, CancellationToken cancellation)
        {
            var result = await _mediator.Send(new CreateTestCommand(dto), cancellation);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPatch]
        public async Task<ActionResult> Update([FromBody] UpdateTestDto dto, CancellationToken cancellation)
        {
            var result = await _mediator.Send(new UpdateTestCommand(dto), cancellation);

            if (result is null)
                return NotFound("Test topilmadi");

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)] 
        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete([FromRoute] long Id, CancellationToken cancellation)
        {
            var result = await _mediator.Send(new DeleteTestCommand(Id), cancellation);

            return Ok(result);
        }
    }
}
