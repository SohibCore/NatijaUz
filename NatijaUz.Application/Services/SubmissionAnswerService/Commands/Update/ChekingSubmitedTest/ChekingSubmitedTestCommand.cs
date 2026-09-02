using MediatR;

namespace NatijaUz.Application.Services.SubmissionAnswerService.Commands.Update.ChekingSubmitedTest
{
    public record ChekingSubmitedTestCommand(long SubmissionId) : IRequest<bool>;
}
