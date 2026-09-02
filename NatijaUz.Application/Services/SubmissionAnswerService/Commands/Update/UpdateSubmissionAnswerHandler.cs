using MediatR;
using NatijaUz.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;
using NatijaUz.Infrastructure.Persistence;
using NatijaUz.Application.Auth.AccountService;
using NatijaUz.Application.Services.SubmissionAnswerService.Dtos;

namespace NatijaUz.Application.Services.SubmissionAnswerService.Commands.Update
{
    public class UpdateSubmissionAnswerHandler : IRequestHandler<UpdateSubmissionAnswerCommand, SubmissionAnswerDto>
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _service;
        public UpdateSubmissionAnswerHandler(AppDbContext context, IAccountService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<SubmissionAnswerDto> Handle(UpdateSubmissionAnswerCommand request, CancellationToken cancellationToken)
        {
            UserRole[] allowedRoles = new UserRole[] { UserRole.SysAdmin, UserRole.CenterAdmin };
            if (!allowedRoles.Contains(_service.Role))
                throw new ForbiddenException("Siz Submission Answerni yangilash uchun ruxsatga ega emassiz");

            var submissionAnswer = await _context.SubmissionAnswers
                .Include(x => x.Submission)
                    .ThenInclude(x => x.Test)
                         .ThenInclude(x => x.Group)
                .FirstOrDefaultAsync(s => s.Id == request.dto.Id && s.Status != Status.Deleted, cancellationToken) ?? throw new NotFoundException("Submission Answer topilmadi");

            if (_service.Role == UserRole.CenterAdmin && _service.LearningCenterId != submissionAnswer.Submission.Test.Group.LearningCenterId)
                throw new ForbiddenException("Siz Submission Answerni yangilash uchun ruxsatga ega emassiz");

            if(request.dto.QuestionNumber.HasValue)
                submissionAnswer.QuestionNumber = request.dto.QuestionNumber.Value;

            if(request.dto.IsCorrect.HasValue)
                submissionAnswer.IsCorrect = request.dto.IsCorrect.Value;

            submissionAnswer.ModifiedAt = DateTime.UtcNow;
            submissionAnswer.ModifiedUserId = _service.UserId;
            await _context.SaveChangesAsync(cancellationToken);
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
