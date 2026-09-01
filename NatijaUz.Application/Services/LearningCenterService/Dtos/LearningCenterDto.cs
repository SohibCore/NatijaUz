using NatijaUz.Domain.Enums;

namespace NatijaUz.Application.Services.LearningCenterService.Dtos
{
    public class LearningCenterDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public long OwnerUserId { get; set; } 
    }
}
