using Domain.Enums;
using ViewModels.BaseDTOs;

namespace ViewModels.ProjectDTOs
{
    public class UpdateCreateProjectDTO : BaseIdDTO
    {
        public int? CustomerId { get; set; }
        public string Name { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public ProjectType? Type { get; set; }
    }
}
