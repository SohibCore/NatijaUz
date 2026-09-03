using MediatR;
using NatijaUz.Domain.Enums;
using SendGrid.Helpers.Errors.Model;
using Microsoft.EntityFrameworkCore;
using NatijaUz.Infrastructure.Persistence;
using NatijaUz.Application.Auth.AccountService;
using NatijaUz.Application.Services.SubmissionAnswerService.Dtos;

namespace NatijaUz.Application.Services.SubmissionAnswerService.Queries.GetById
{
    public class GetByIdHandler : IRequestHandler<GetByIdQuery, SubmissionAnswerDto>
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _service;
        public GetByIdHandler(AppDbContext context, IAccountService accountService)
        {
            _context = context;
            _service = accountService;
        }
        public async Task<SubmissionAnswerDto> Handle(GetByIdQuery request, CancellationToken cancellation)
        {
            var submissionAnswer = await _context.SubmissionAnswers
                .Include(x => x.Submission)
                    .ThenInclude(x => x.Test)
                         .ThenInclude(x => x.Group)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.Status != Status.Deleted, cancellation) ?? throw new NotFoundException("Submission Answer topilmadi");

            switch (_service.Role)
            {
                case UserRole.SysAdmin:
                    break;

                case UserRole.Owner:
                    if (_service.LearningCenterId != submissionAnswer.Submission.Test.Group.LearningCenterId)
                        throw new ForbiddenException("Faqat o'z markazingizdagi testni ko'ra olasiz");
                    break;

                case UserRole.CenterAdmin:
                    if (_service.LearningCenterId != submissionAnswer.Submission.Test.Group.LearningCenterId)
                        throw new ForbiddenException("Faqat o'z markazingizdagi testni ko'ra olasiz");
                    break;

                case UserRole.Teacher:
                    if (submissionAnswer.Submission.Test.Group.TeacherId != _service.UserId)
                        throw new ForbiddenException("Faqat o'z guruhingizning testini ko'ra olasiz");
                    break;

                case UserRole.Student:
                    if (submissionAnswer.Submission.StudentId != _service.UserId)
                        throw new ForbiddenException("Faqat o'z testingizni ko'ra olasiz");
                    break;

                default:
                    throw new ForbiddenException("Sizda ruxsat yo'q");
            }

            return new SubmissionAnswerDto
            {
                Id = submissionAnswer.Id,
                SubmissionId = submissionAnswer.SubmissionId,
                QuestionNumber = submissionAnswer.QuestionNumber,
                DetectedAnswer = submissionAnswer.DetectedAnswer,
                IsCorrect = submissionAnswer.IsCorrect
            };
        }
    }
}
