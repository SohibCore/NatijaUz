using MediatR;
using NatijaUz.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;
using NatijaUz.Infrastructure.Persistence;
using NatijaUz.Application.Auth.AccountService;
using NatijaUz.Application.Services.TestService.Dtos;

namespace NatijaUz.Application.Services.TestService.Queries.GetById
{
    public class GetByIdHandler : IRequestHandler<GetByIdQuery, TestDto>
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _service;
        public GetByIdHandler(AppDbContext context, IAccountService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<TestDto> Handle(GetByIdQuery reqeust, CancellationToken cancellation)
        {
            var test = await _context.Tests
                .AsNoTracking()
                .Where(x => x.Id == reqeust.Id && x.Status != Status.Deleted)
                .Select(x => new TestDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    GroupId = x.GroupId,
                    Deadline = x.Deadline,
                    IsActive = x.IsActive,
                    QuestionCount = x.QuestionCount,
                }).FirstOrDefaultAsync(cancellation) ?? throw new NotFoundException("Test topilmadi");
            
            var group = await _context.Groups.SingleOrDefaultAsync(x => x.Id == test.GroupId && x.Status != Status.Deleted, cancellation) ?? throw new NotFoundException("Guruh topilmadi");

            switch (_service.Role)
            {
                case UserRole.SysAdmin:
                    break;

                case UserRole.CenterAdmin:
                    if (_service.LearningCenterId != group.LearningCenterId)
                        throw new ForbiddenException("Faqat o'z markazingizdagi testni ko'ra olasiz");
                    break;

                case UserRole.Student:
                    var member = await _context.GroupMembers.AnyAsync(x => x.GroupId == group.Id && x.StudentId == _service.UserId, cancellation);
                    if (!member)
                        throw new ForbiddenException("Siz bu guruhga a'zo emassiz");
                    break;

                case UserRole.Teacher:
                    if (group.TeacherId != _service.UserId)
                        throw new ForbiddenException("Faqat o'z guruhingizning testini ko'ra olasiz");
                    break;

                default:
                    throw new ForbiddenException("Sizda ruxsat yo'q");
            }

            return test;
        }
    }
}
