using MediatR;
using Microsoft.EntityFrameworkCore;
using NatijaUz.Application.Auth.Services;
using NatijaUz.Infrastructure.Persistence;

namespace NatijaUz.Application.Services.UserService.Commands.Delete
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _service;
        public DeleteUserHandler(IAccountService service, AppDbContext context)
        {
            _context = context;
            _service = service;
        }
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellation)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == _service.UserId, cancellation);

            if (user == null)
                throw new Exception("Foydalanuvchi topilmadi");
        }
    }
}
