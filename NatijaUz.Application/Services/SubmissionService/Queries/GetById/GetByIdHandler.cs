using MediatR;
using Microsoft.EntityFrameworkCore;
using NatijaUz.Application.Auth.AccountService;
using NatijaUz.Application.Services.SubmissionService.Dtos;
using NatijaUz.Domain.Entity;
using NatijaUz.Domain.Enums;
using NatijaUz.Infrastructure.Persistence;
using SendGrid.Helpers.Errors.Model;

namespace NatijaUz.Application.Services.SubmissionService.Queries.GetById
{
    public class GetByIdHandler : IRequestHandler<GetByIdQuery, SubmissionDto>
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _service;
        public GetByIdHandler(AppDbContext context, IAccountService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<SubmissionDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var submission = await _context.Submissions
                .AsNoTracking()
                .Where(s => s.Id == request.Id && s.Status != Domain.Enums.Status.Deleted)
                .Select(x => new SubmissionDto
                {
                    Id = x.Id,
                    StudentId = x.StudentId,
                    CorrectCount = x.CorrectCount,
                    SubmissionStatus = x.SubmissionStatus,
                    SubmittedAt = x.SubmittedAt,
                    TestId = x.TestId,
                    TotalScore = x.TotalScore,
                }).FirstOrDefaultAsync(cancellationToken) ?? throw new NotFoundException("Topshiriq topilmadi");

            var test = await _context.Tests.Include(x => x.Group).SingleOrDefaultAsync(x => x.Id == submission.TestId, cancellationToken) ?? throw new NotFoundException("Test topilmadi");

            var learningCenter = await _context.LearningCenters.SingleOrDefaultAsync(x => x.Id == test.Group.LearningCenterId, cancellationToken) ?? throw new NotFoundException("Markaz topilmadi");

            switch (_service.Role)
            {
                case UserRole.SysAdmin:
                    break;

                case UserRole.Owner:
                    if (_service.LearningCenterId != learningCenter.Id)
                        throw new ForbiddenException("Faqat o'z markazingizdagi testni ko'ra olasiz");
                    break;

                case UserRole.CenterAdmin:
                    if (_service.LearningCenterId != test.Group.LearningCenterId)
                        throw new ForbiddenException("Faqat o'z markazingizdagi testni ko'ra olasiz");
                    break;

                case UserRole.Student:
                    var member = await _context.GroupMembers.AnyAsync(x => x.GroupId == test.Group.Id && x.StudentId == _service.UserId, cancellationToken);
                    if (!member)
                        throw new ForbiddenException("Siz bu guruhga a'zo emassiz");
                    break;

                case UserRole.Teacher:
                    if (test.Group.TeacherId != _service.UserId)
                        throw new ForbiddenException("Faqat o'z guruhingizning testini ko'ra olasiz");
                    break;

                default:
                    throw new ForbiddenException("Sizda ruxsat yo'q");
            }
            return submission;
        }
    }
}
