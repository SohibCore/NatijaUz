using MediatR;
using Microsoft.EntityFrameworkCore;
using NatijaUz.Infrastructure.Persistence;
using NatijaUz.Application.Auth.AccountService;

namespace NatijaUz.Application.Services.UserService.Commands.Password
{
    public class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand, bool>
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _service;
        public ChangePasswordHandler(AppDbContext context, IAccountService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellation)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == _service.UserId && x.Status != Domain.Enums.Status.Deleted, cancellation) ?? throw new Exception("Foydalanuvchi topilmadi!");

            if (!BCrypt.Net.BCrypt.Verify(request.OldPassword, user.PasswordHash))
                throw new Exception("Eski parolingiz xato!");

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
            user.ModifiedAt = DateTime.UtcNow;
            user.ModifiedUserId = _service.UserId;

            await _context.SaveChangesAsync(cancellation);
            return true;
        }
    }
}
