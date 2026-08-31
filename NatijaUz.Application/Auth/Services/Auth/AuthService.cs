using MediatR;
using Microsoft.EntityFrameworkCore;
using NatijaUz.Application.Auth.AuthDto;
using NatijaUz.Application.Services.UserService.Dtos;
using NatijaUz.Domain.Entity;
using NatijaUz.Infrastructure.Persistence;
using System.Security.Claims;

namespace NatijaUz.Application.Auth.Services.Auth
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
        public async Task<AuthResult> RegisterAsync(CreateUserDto dto, CancellationToken cancellationToken)
        {
            var userNameTaken = await _context.Users.SingleOrDefaultAsync(x => x.UserName == dto.UserName, cancellationToken) ?? throw new Exception("$'{dto.UserName}' foydalanuvchi nomib allaqachon band.");

            var user = new User
            {
                UserName = dto.UserName,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                FullName = dto.FullName,
                PhoneNumber = dto.PhoneNumber,
                Status = Domain.Enums.Status.Created,

                CreatedAt = DateTime.UtcNow
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
                throw new Exception("UserName	yoki	parol	noto'g'ri.");

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
