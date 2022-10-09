using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Project : BaseModel
    {
        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public string Name { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public virtual List<EmployeeProjectTask> EmployeeProjectTasks { get; set; }

        [EnumDataType(typeof(ProjectType))]
        public ProjectType? Type { get; set; }
    }
}
