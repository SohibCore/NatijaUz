using MediatR;
using Microsoft.AspNetCore.Mvc;
using NatijaUz.Application.Services.UserService.Dtos;
using NatijaUz.Application.Services.UserService.Commands.Create;
using NatijaUz.Application.Services.UserService.Commands.Delete;
using NatijaUz.Application.Services.UserService.Commands.Update;
using NatijaUz.Application.Services.UserService.Queries.GetById;
using NatijaUz.Application.Services.UserService.Queries.GetList;
using NatijaUz.Application.Services.UserService.Commands.Password;

namespace NatijaUz.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        public async Task<ActionResult> GetList([FromQuery] UserFilterDto filter)
        {
            var result = await _mediator.Send(new GetListCommand(filter));

            if (result is null || result.Count() == 0)
                return NotFound("Foydalanuvchilar topilmadi");

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("{Id}")]
        public async Task<ActionResult> Get([FromRoute] long Id)
        {
            var result = await _mediator.Send(new GetByIdCommand(Id));

            if (result is null)
                return NotFound("Foydalanuvchi topilmadi");

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateUserDto dto, CancellationToken cancellation)
        {
            var result = await _mediator.Send(new CreateUserCommand(dto), cancellation);

            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPatch]
        public async Task<ActionResult> Update([FromBody] UpdateUserDto dto, CancellationToken cancellation)
        {
            var result = await _mediator.Send(new UpdateUserCommand(dto), cancellation);
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete([FromRoute] long Id, CancellationToken cancellation)
        {
            var result = await _mediator.Send(new DeleteUserCommand(Id), cancellation);
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public async Task<ActionResult> ChangePassword(PasswordDto dto, CancellationToken cancellation)
        {
            var result = await _mediator.Send(new ChangePasswordCommand(dto), cancellation);
            return Ok(result);
        }
    }
}
