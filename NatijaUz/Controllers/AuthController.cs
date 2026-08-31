using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NatijaUz.Application.Auth.AuthDto;
using NatijaUz.Application.Auth.Services.Auth;
using NatijaUz.Application.Auth.Services.RegisterService.Commands.Register;
using NatijaUz.Application.Auth.Services.RegisterService.Commands.VerifyEmail;
using SendGrid.Helpers.Errors.Model;
using System.Security.Claims;

namespace NatijaUz.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        private readonly IMediator _mediator;
        public AuthController(IAuthService authService, IMediator mediator)
        {
            _service = authService;
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command, CancellationToken cancel)
        {
            try
            {
                await _mediator.Send(command, cancel);
                return Ok(new { message = "Tasdiqlash kodi emailga yuborildi" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Register ERROR: {ex}");
                return BadRequest(new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto dto, CancellationToken cancel)
        {
            try
            {
                var result = await _service.LoginAsync(dto, cancel);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, result.ClaimsPrincipal);
                return Ok(new { result.UserId, result.UserName });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult Me()
        {
            if (User.Identity?.IsAuthenticated != true)
                return Unauthorized();

            return Ok(new
            {
                UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                UserName = User.Identity!.Name,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("verify-email")]
        public async Task<IActionResult> VerifyEmail([FromBody] VerifyEmailCommand command, CancellationToken ct)
        {
            try
            {
                var result = await _mediator.Send(command, ct);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    result.ClaimsPrincipal);
                return Ok(new { userId = result.UserId, userName = result.UserName });
            }
            catch (BadRequestException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
