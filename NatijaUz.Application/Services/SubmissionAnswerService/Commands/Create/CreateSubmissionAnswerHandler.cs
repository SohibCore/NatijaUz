using MediatR;
using NatijaUz.Domain.Enums;
using NatijaUz.Domain.Entity;
using SendGrid.Helpers.Errors.Model;
using Microsoft.EntityFrameworkCore;
using NatijaUz.Infrastructure.Persistence;
using NatijaUz.Application.Auth.AccountService;
using NatijaUz.Application.Services.SubmissionAnswerService.Dtos;

namespace NatijaUz.Application.Services.SubmissionAnswerService.Commands.Create
{
    public class CreateSubmissionAnswerHandler : IRequestHandler<CreateSubmissionAnswerCommand, SubmissionAnswerDto>
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _service;
        public CreateSubmissionAnswerHandler(AppDbContext context, IAccountService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<SubmissionAnswerDto> Handle(CreateSubmissionAnswerCommand request, CancellationToken cancellation)
        {
            UserRole[] allowedRoles = new UserRole[] { UserRole.CenterAdmin, UserRole.SysAdmin };

            if (!allowedRoles.Contains(_service.Role))
                throw new ForbiddenException("Siz test yarata olmaysiz");

            var submission = await _context.Submissions
                .Include(x => x.Student)
                .FirstOrDefaultAsync(s => s.Id == request.dto.SubmissionId, cancellation) ?? throw new NotFoundException("Submission topilmadi");

            if (_service.Role == UserRole.CenterAdmin && _service.LearningCenterId != submission.Student.LearningCenterId)
                throw new ForbiddenException("Faqat o'z markazingizdagi guruhga Submission qo'sha olasiz");

            var submissionAnswer = new SubmissionAnswer
            {
                SubmissionId = request.dto.SubmissionId,
                QuestionNumber = request.dto.QuestionNumber,
                DetectedAnswer = request.dto.DetectedAnswer,
                IsCorrect = request.dto.IsCorrect,

                CreatedAt = DateTime.UtcNow,
                CreateUserId = _service.UserId,
            };

            await _context.SubmissionAnswers.AddAsync(submissionAnswer, cancellation);
            await _context.SaveChangesAsync(cancellation);

            return new SubmissionAnswerDto
            {
                Id = submissionAnswer.Id,
                SubmissionId = submissionAnswer.SubmissionId,
                QuestionNumber = submissionAnswer.QuestionNumber,
                DetectedAnswer = submissionAnswer.DetectedAnswer,
                IsCorrect = submissionAnswer.IsCorrect,
            };
        }
    }
}
