using MediatR;
using NatijaUz.Domain.Enums;
using SendGrid.Helpers.Errors.Model;
using Microsoft.EntityFrameworkCore;
using NatijaUz.Infrastructure.Persistence;
using NatijaUz.Application.Auth.AccountService;
using NatijaUz.Application.Services.SubmissionAnswerService.Dtos;
using NatijaUz.Application.Services.SubmissionAnswerService.Queries.ObjectQueries;

namespace NatijaUz.Application.Services.SubmissionAnswerService.Queries.GetList
{
    public class GetListHandler : IRequestHandler<GetListQuery, List<SubmissionAnswerListDto>>
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _service;
        public GetListHandler(AppDbContext context, IAccountService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<List<SubmissionAnswerListDto>> Handle(GetListQuery request, CancellationToken cancellationToken)
        {
            var query = _context.SubmissionAnswers
                .AsNoTracking()
                .Where(x => x.Status != Status.Deleted);

            query = _service.Role switch
            {
                UserRole.SysAdmin => query,

                UserRole.CenterAdmin => query.Where(x => x.Submission.Test.Group.LearningCenterId == _service.LearningCenterId),

                UserRole.Teacher => query.Where(x => x.Id == _service.UserId),

                UserRole.Student => query.Where(x => x.Id == _service.UserId),

                _ => throw new ForbiddenException("Sizda ruxsat yo'q")
            };

            return await query
               .Select(x => new SubmissionAnswerListDto
               {
                   Id = x.Id,
                   SubmissionId = x.SubmissionId,
                   QuestionNumber = x.QuestionNumber,
                   DetectedAnswer = x.DetectedAnswer,
                   IsCorrect = x.IsCorrect
               }).SortFilter(request.filter)
               .ToListAsync(cancellationToken);
        }
    }
}
