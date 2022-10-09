using ViewModels.BaseDTOs;

namespace ViewModels.ProjectDTOs
{
    public class ShortProjectDTO : BaseIdDTO
    {
        public string Name { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
    }
}
