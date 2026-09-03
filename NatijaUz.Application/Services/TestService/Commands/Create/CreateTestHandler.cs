using MediatR;
using NatijaUz.Domain.Enums;
using NatijaUz.Domain.Entity;
using NatijaUz.Application.Common;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;
using NatijaUz.Infrastructure.Persistence;
using NatijaUz.Application.Auth.AccountService;
using NatijaUz.Application.Services.TestService.Dtos;

namespace NatijaUz.Application.Services.TestService.Commands.Create
{
    public class CreateTestHandler : IRequestHandler<CreateTestCommand, TestDto>
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _service;
        public CreateTestHandler(AppDbContext context, IAccountService service)
        {
            _context = context;
            _service = service;
        }

        public async Task<TestDto> Handle(CreateTestCommand request, CancellationToken cancellation)
        {
            UserRole[] allowedRoles = new UserRole[] { UserRole.CenterAdmin, UserRole.SysAdmin };

            if (!allowedRoles.Contains(_service.Role))
                throw new ForbiddenException("Siz test yarata olmaysiz");

            var group = await _context.Groups.SingleOrDefaultAsync(x => x.Id == request.dto.GroupId, cancellation);

            if (group == null)
                throw new NotFoundException("Guruh topilmadi");

            if (RolePermissions.IsCenterManager(_service.Role) && _service.LearningCenterId != group.LearningCenterId)
                throw new ForbiddenException("Faqat o'z markazingizdagi guruhga test qo'sha olasiz");

            var test = new Test
            {
                Title = request.dto.Title,
                GroupId = request.dto.GroupId,
                QuestionCount = request.dto.QuestionCount,
                Deadline = request.dto.Deadline,
                IsActive = true,
                Status = Status.Created,

                CreatedAt = DateTime.UtcNow,
                CreateUserId = _service.UserId
            };

            await _context.AddAsync(test, cancellation);
            await _context.SaveChangesAsync(cancellation);

            return new TestDto
            {
                Id = test.Id,
                Title = test.Title,
                GroupId = test.GroupId,
                QuestionCount = test.QuestionCount,
                Deadline = test.Deadline,
                IsActive = test.IsActive,
            };
        }
    }
}
