using ViewModels.BaseDTOs;

namespace ViewModels.ProjectDTOs
{
    public class DetailedProjectDTO : BaseIdDTO
    {
        public string Name { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string CustomerFullName { get; set; }
        public string Type { get; set; }
    }
}
