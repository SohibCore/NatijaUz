using MediatR;
using Microsoft.AspNetCore.Mvc;
using NatijaUz.Application.Services.SubmissionService.Dtos;
using NatijaUz.Application.Services.SubmissionService.Commands.Create;
using NatijaUz.Application.Services.SubmissionService.Commands.Delete;
using NatijaUz.Application.Services.SubmissionService.Commands.Update;
using NatijaUz.Application.Services.SubmissionService.Queries.GetById;
using NatijaUz.Application.Services.SubmissionService.Queries.GetList;

namespace NatijaUz.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SubmissionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SubmissionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        public async Task<IActionResult> GetList([FromBody] SubmissionFilterDto filter, CancellationToken cancellation)
        {
            var result = await _mediator.Send(new GetListQuery(filter), cancellation);

            if (result is null || result.Count() == 0)
                return NotFound("Topshiriq topilmadi");

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(long Id, CancellationToken cancellation)
        {
            var result = await _mediator.Send(new GetByIdQuery(Id), cancellation);

            if (result is null)
                return NotFound("Topshiriq topilmadi");

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSubmissionDto dto, CancellationToken cancellation)
        {
            var result = await _mediator.Send(new CreateSubmissionCommand(dto), cancellation);

            if (result is null)
                return BadRequest("Topshiriq yaratilmadi");

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] UpdateSubmissionDto dto, CancellationToken cancellation)
        {
            var result = await _mediator.Send(new UpdateSubmissionCommand(dto), cancellation);

            if (result is null)
                return BadRequest("Topshiriq yangilanmadi");

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id, CancellationToken cancellation)
        {
            var result = await _mediator.Send(new DeleteSubmissionCommand(Id), cancellation);

            return Ok(result);
        }
    }
}
