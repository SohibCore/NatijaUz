using MediatR;
using NatijaUz.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using NatijaUz.Application.Auth.Services;
using NatijaUz.Infrastructure.Persistence;
using NatijaUz.Application.Services.UserService.Dtos;


namespace NatijaUz.Application.Services.UserService.Commands.Create.Student
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _service;
        public CreateUserHandler(AppDbContext context, IAccountService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellation)
        {
            var phoneNumber = await _context.Users.AnyAsync(x => x.PhoneNumber == request.dto.PhoneNumber, cancellation);

            if (phoneNumber)
                throw new Exception($"Bu raqam band - {request.dto.PhoneNumber}, iltimos boshqa raqamdan foydalaning");

            var userName = await _context.Users.AnyAsync(x => x.UserName == request.dto.UserName, cancellation);

            if (userName)
                throw new Exception($"Bu nom band - {request.dto.UserName}, iltimos boshqa nomdan foydalaning");

            var student = new User
            {
                UserName = request.dto.UserName,
                FullName = request.dto.FullName,
                PhoneNumber = request.dto.PhoneNumber,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.dto.Password),
                Role = Domain.Enums.UserRole.Student,
                LearningCenterId = null,

                CreatedAt = DateTime.UtcNow,
                CreateUserId = _service.UserId,
            };

            await _context.Users.AddAsync(student, cancellation);
            await _context.SaveChangesAsync(cancellation);

            return new UserDto
            {
                Id = student.Id,
                FullName = student.FullName,
                PhoneNumber = student.PhoneNumber,
                Password = student.PasswordHash,
            };
        }
    }
}
