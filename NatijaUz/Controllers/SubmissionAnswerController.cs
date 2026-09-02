using MediatR;
using Microsoft.AspNetCore.Mvc;
using NatijaUz.Application.Services.SubmissionAnswerService.Dtos;
using NatijaUz.Application.Services.SubmissionAnswerService.Commands.Create;
using NatijaUz.Application.Services.SubmissionAnswerService.Commands.Delete;
using NatijaUz.Application.Services.SubmissionAnswerService.Commands.Update;
using NatijaUz.Application.Services.SubmissionAnswerService.Queries.GetById;
using NatijaUz.Application.Services.SubmissionAnswerService.Queries.GetList;

namespace NatijaUz.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SubmissionAnswerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SubmissionAnswerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        public async Task<ActionResult> GetList([FromQuery] SubmissionAnswerFilterDto filter, CancellationToken cancellation)
        {
            var result = await _mediator.Send(new GetListQuery(filter), cancellation);

            if (result is null || result.Count() == 0)
                return NotFound("Submission answers topilmadi");

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
                return NotFound("Submission answer topilmadi");

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateSubmissionAnswerDto dto, CancellationToken cancellation)
        {
            var result = await _mediator.Send(new CreateSubmissionAnswerCommand(dto), cancellation);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPatch]
        public async Task<ActionResult> Update([FromBody] UpdateSubmissionAnswerDto dto, CancellationToken cancellation)
        {
            var result = await _mediator.Send(new UpdateSubmissionAnswerCommand(dto), cancellation);

            if (result is null)
                return NotFound("Submission answer topilmadi");

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery] long Id, CancellationToken cancellation)
        {
            var result = await _mediator.Send(new DeleteSubmissionAnswerCommand(Id), cancellation);
            return Ok(result);
        }
    }
}
