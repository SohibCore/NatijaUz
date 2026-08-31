using MediatR;
using Microsoft.EntityFrameworkCore;
using NatijaUz.Application.Auth.AuthDto;
using NatijaUz.Infrastructure.Persistence;
using NatijaUz.Application.Auth.Services.Auth;
using NatijaUz.Application.Services.UserService.Dtos;

namespace NatijaUz.Application.Auth.Services.RegisterService.Commands.VerifyEmail
{
    public class VerifyEmailCommandHandler : IRequestHandler<VerifyEmailCommand, AuthResult>
    {
        private readonly AppDbContext _context;
        private readonly IAuthService _authService;

        public VerifyEmailCommandHandler(AppDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public async Task<AuthResult> Handle(VerifyEmailCommand request, CancellationToken cancellation)
        {
            var pending = await _context.PendingRegistrations
                .SingleOrDefaultAsync(x => x.Email == request.Email, cancellation);

            if (pending is null)
                throw new Exception("Ro'yxatdan o'tish topilmadi, qaytadan urinib ko'ring");

            if (pending.ExpiresAt < DateTime.UtcNow)
                throw new Exception("Kod muddati tugagan");

            if (pending.Code != request.Code)
            {
                pending.AttemptCount++;
                await _context.SaveChangesAsync(cancellation);
                throw new Exception("Kod noto'g'ri");
            }

            var dto = new CreateUserDto
            {
                UserName = pending.UserName,
                Password = pending.Password,
                FullName = pending.FullName,
                PhoneNumber = pending.PhoneNumber,
                Email = pending.Email,
                Pinfl = pending.Pinfl,
                Address = pending.Address,
                DateOfBirth = pending.DateOfBirth,
                LearningCenterId = pending.LearningCenterId,
                Role = pending.Role
            };

            var authResult = await _authService.RegisterAsync(dto, cancellation);

            _context.PendingRegistrations.Remove(pending);
            await _context.SaveChangesAsync(cancellation);

            return authResult;
        }
    }
}
