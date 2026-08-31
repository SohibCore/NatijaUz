using MediatR;
using NatijaUz.Domain.Entity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using NatijaUz.Application.Auth.AuthDto;
using NatijaUz.Infrastructure.Persistence;
using NatijaUz.Application.Auth.Services.VerifyEmail.Commands;
using NatijaUz.Application.Auth.Services.RegisterService.Dtos;

namespace NatijaUz.Application.Auth.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;
        public AuthService(AppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task<AuthResult> RegisterAsync(RegisterDto dto, CancellationToken cancellationToken)
        {
            var userNameTaken = await _context.Users.SingleOrDefaultAsync(x => x.UserName == dto.UserName, cancellationToken) ?? throw new Exception($"'{dto.UserName}' foydalanuvchi nomib allaqachon band.");

            var user = new User
            {
                UserName = dto.UserName,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                FullName = dto.FullName,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                Address = dto.Address,
                Pinfl = dto.Pinfl,
                DateOfBirth = dto.DateOfBirth,

                CreatedAt = DateTime.UtcNow,
                Status = Domain.Enums.Status.Created,
            };
            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new AuthResult
            {
                UserId = user.Id,
                UserName = user.UserName,
                LearningCenterId = user.LearningCenterId,
                Role = user.Role,
                ClaimsPrincipal = BuildClaimsPrincipal(user)
            };
        }

        public async Task<AuthResult> LoginAsync(LoginDto dto, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(x => x.UserName == dto.UserName, cancellationToken);

            if (user is null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                throw new Exception("UserName yoki parol noto'g'ri.");

            if (user.Status == Domain.Enums.Status.Deleted)
                throw new Exception("Bu hisob o'chirilgan");

            return new AuthResult
            {
                UserId = user.Id,
                UserName = user.UserName,
                LearningCenterId = user.LearningCenterId,
                Role = user.Role,
                ClaimsPrincipal = BuildClaimsPrincipal(user)
            };
        }
        private static ClaimsPrincipal BuildClaimsPrincipal(User user)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.Role, user.Role.ToString()),
                new("LearningCenterId", user.LearningCenterId?.ToString() ?? string.Empty),
            };

            var identity = new ClaimsIdentity(claims, "Cookies");
            return new ClaimsPrincipal(identity);
        }
        public async Task<AuthResult> VerifyEmailAsync(VerifyEmailCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
