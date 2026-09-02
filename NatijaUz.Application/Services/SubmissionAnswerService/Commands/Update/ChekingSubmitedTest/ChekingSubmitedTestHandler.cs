using MediatR;
using NatijaUz.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;
using NatijaUz.Infrastructure.Persistence;
using NatijaUz.Application.Auth.AccountService;

namespace NatijaUz.Application.Services.SubmissionAnswerService.Commands.Update.ChekingSubmitedTest
{
    public class ChekingSubmitedTestHandler : IRequestHandler<ChekingSubmitedTestCommand, bool>
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _service;
        public ChekingSubmitedTestHandler(AppDbContext context, IAccountService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<bool> Handle(ChekingSubmitedTestCommand request, CancellationToken cancellation)
        {
            var submission = await _context.Submissions.FirstOrDefaultAsync(x => x.Id == request.SubmissionId && x.Status != Status.Deleted, cancellation) ?? throw new NotFoundException("Submission topilmadi");

            if (submission.StudentId != _service.UserId)
                throw new ForbiddenException("Faqat o'z javobingizni yuborishingiz mumkin");

            if (submission.SubmissionStatus != SubmissionStatus.Draft)
                throw new BadRequestException("Bu javob allaqachon yuborilgan");

            submission.SubmissionStatus = SubmissionStatus.Submitted;
            await _context.SaveChangesAsync(cancellation);
            return true;
        }
    }
}
