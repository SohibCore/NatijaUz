using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NatijaUz.Application.Auth.Services.Auth;
using NatijaUz.Application.Services.UserService.Dtos;

namespace NatijaUz.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService authService)
        {
            _service = authService;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Register([FromBody] CreateUserDto dto, CancellationToken cancellationToken)
        {
            var result = await _service.RegisterAsync(dto, cancellationToken);
            await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            result.ClaimsPrincipal);
            return Ok(new { result.UserId, result.UserName, result.LearningCenterId, result.Role });
        }
    }
}
