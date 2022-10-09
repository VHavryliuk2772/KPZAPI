namespace Domain.Models
{
    public class DesignTask : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<EmployeeProjectTask> EmployeeProjectTasks { get; set; }
    }
}
