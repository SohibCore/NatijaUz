using MediatR;
using NatijaUz.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;
using NatijaUz.Infrastructure.Persistence;
using NatijaUz.Application.Auth.AccountService;
using NatijaUz.Application.Services.TestService.Dtos;

namespace NatijaUz.Application.Services.TestService.Commands.Update
{
    public class UpdateTestHandler : IRequestHandler<UpdateTestCommand, TestDto>
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _service;
        public UpdateTestHandler(AppDbContext context, IAccountService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<TestDto> Handle(UpdateTestCommand request, CancellationToken cancellation)
        {
            var allowedRoles = new UserRole[] { UserRole.SysAdmin, UserRole.CenterAdmin };

            if (!allowedRoles.Contains(_service.Role))
                throw new ForbiddenException("Siz testni yangilay olmaysiz");

            var test = await _context.Tests
                .Include(x => x.Group)
                .FirstOrDefaultAsync(x => x.Id == request.dto.Id && x.Status != Status.Deleted, cancellation) ?? throw new NotFoundException("Test topilmadi");

            if (_service.Role == UserRole.CenterAdmin && _service.LearningCenterId != test.Group.LearningCenterId)
                throw new ForbiddenException("Faqat o'z markazingizdagi testni yangilay olasiz");

            var hasSubmissions = await _context.Submissions.AnyAsync(x => x.TestId == test.Id && x.Status != Status.Deleted, cancellation);

            if (hasSubmissions && request.dto.QuestionCount.HasValue && test.QuestionCount != request.dto.QuestionCount)
                throw new BadRequestException("Talabalar javob topshirgan testning savollar sonini o'zgartirib bo'lmaydi");

            if (!string.IsNullOrWhiteSpace(request.dto.Title))
                test.Title = request.dto.Title;

            if (request.dto.Deadline.HasValue)
                test.Deadline = request.dto.Deadline.Value;

            if (request.dto.QuestionCount.HasValue && !hasSubmissions)
                test.QuestionCount = request.dto.QuestionCount.Value;

            if (request.dto.IsActive.HasValue)
                test.IsActive = request.dto.IsActive.Value;

            test.ModifiedAt = DateTime.UtcNow;
            test.ModifiedUserId = _service.UserId;
            await _context.SaveChangesAsync(cancellation);

            return new TestDto
            {
                Id = test.Id,
                Title = test.Title,
                Deadline = test.Deadline,
                QuestionCount = test.QuestionCount,
                GroupId = test.GroupId,
                IsActive = test.IsActive,
            };
        }
    }
}
