using MediatR;
using Microsoft.EntityFrameworkCore;
using NatijaUz.Application.Auth.AccountService;
using NatijaUz.Application.Common;
using NatijaUz.Application.Services.LearningCenterService.Dtos;
using NatijaUz.Domain.Entity;
using NatijaUz.Domain.Enums;
using NatijaUz.Infrastructure.Persistence;
using SendGrid.Helpers.Errors.Model;
using static System.Net.Mime.MediaTypeNames;

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

        }
    }
}
