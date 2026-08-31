using MediatR;
using SendGrid.Helpers.Errors.Model;
using Microsoft.EntityFrameworkCore;
using NatijaUz.Application.Auth.AuthDto;
using NatijaUz.Infrastructure.Persistence;
using NatijaUz.Application.Auth.AuthService;
using NatijaUz.Application.Auth.Services.RegisterService.Dtos;

namespace NatijaUz.Application.Auth.Services.VerifyEmail.Commands
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
            var email = request.Email.Trim().ToLower();

            var pending = await _context.PendingRegistrations
                .SingleOrDefaultAsync(x => x.Email == email, cancellation);

            if (pending is null)
                throw new NotFoundException("Ro'yxatdan o'tish topilmadi, qaytadan urinib ko'ring");

            if (pending.ExpiresAt < DateTime.UtcNow)
                throw new BadRequestException("Kod muddati tugagan");

            if (pending.Code != request.Code)
            {
                pending.AttemptCount++;
                await _context.SaveChangesAsync(cancellation);
                throw new BadRequestException("Kod noto'g'ri");
            }

            var dto = new RegisterDto
            {
                UserName = pending.UserName,
                Password = pending.Password,
                FullName = pending.FullName,
                PhoneNumber = pending.PhoneNumber,
                Email = pending.Email,
                Pinfl = pending.Pinfl,
                Address = pending.Address,
                DateOfBirth = pending.DateOfBirth,
            };

            var authResult = await _authService.RegisterAsync(dto, cancellation);

            _context.PendingRegistrations.Remove(pending);
            await _context.SaveChangesAsync(cancellation);

            return authResult;
        }
    }
}
