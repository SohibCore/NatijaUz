using MediatR;
using NatijaUz.Domain.Enums;
using NatijaUz.Domain.Entity;
using SendGrid.Helpers.Errors.Model;
using Microsoft.EntityFrameworkCore;
using NatijaUz.Infrastructure.Persistence;
using NatijaUz.Application.Auth.AccountService;
using NatijaUz.Application.Services.UserService.Dtos;
using NatijaUz.Application.Services.LearningCenterService.Dtos;


namespace NatijaUz.Application.Services.LearningCenterService.Commands.Create
{
    public class CreateLearningCenterHandler : IRequestHandler<CreateLearningCenterCommand, LearningCenterDto>
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _service;
        public CreateLearningCenterHandler(AppDbContext context, IAccountService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<LearningCenterDto> Handle(CreateLearningCenterCommand request, CancellationToken cancel)
        {
            var learningCenter = new LearningCenter
            {
                Name = request.centerDto.Name,
                Address = request.centerDto.Address,
                PhoneNumber = request.centerDto.PhoneNumber,
                Status = Status.Created,

                CreatedAt = DateTime.UtcNow,
            };

            await _context.LearningCenters.AddAsync(learningCenter, cancel);
            await _context.SaveChangesAsync(cancel);

            var existCenter = await _context.LearningCenters.SingleOrDefaultAsync(x => x.Id == learningCenter.Id, cancel);

            if (existCenter is not null)
            {
                var user = new User
                {
                    UserName = request.userDto.UserName,
                    FullName = request.userDto.FullName,
                    PhoneNumber = request.userDto.PhoneNumber,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.userDto.Password),
                    Role = UserRole.Owner,
                    LearningCenterId = learningCenter.Id,
                    Status = Status.Created,

                    CreatedAt = DateTime.UtcNow,
                    CreateUserId = _service.UserId,
                };

                await _context.Users.AddAsync(user, cancel);
                await _context.SaveChangesAsync(cancel);

                learningCenter.OwnerId = user.Id;
                learningCenter.CreateUserId = user.Id;

                await _context.SaveChangesAsync(cancel);
            }
            else
                throw new NotFoundException("O'quv markaz mavjud emas");

            return new LearningCenterDto
            {
                Id = learningCenter.Id,
                Name = learningCenter.Name,
                Address = learningCenter.Address,
                PhoneNumber = learningCenter.PhoneNumber,
                OwnerId = learningCenter.OwnerId,
                Owner = new UserDto
                {
                    Id = learningCenter.OwnerId ?? 0,
                    UserName = request.userDto.UserName,
                    FullName = request.userDto.FullName,
                    PhoneNumber = request.userDto.PhoneNumber,
                    Role = UserRole.Owner,
                }
            };
        }
    }
}
