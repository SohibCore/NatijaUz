using MediatR;
using NatijaUz.Application.Auth.AccountService;
using NatijaUz.Application.Common;
using NatijaUz.Application.Services.LearningCenterService.Dtos;
using NatijaUz.Domain.Entity;
using NatijaUz.Infrastructure.Persistence;

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
            if (_service.Role != Domain.Enums.UserRole.SysAdmin)
                throw new Exception("Siz ushbu O'quv Markazni yarata olmaysiz");

            var learningCenter = new LearningCenter
            {

            }
        }
    }
}
