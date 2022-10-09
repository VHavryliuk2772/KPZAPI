namespace Domain.Models
{
    public class EmployeeProjectTask : BaseModel
    {
        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int? DesignTaskId { get; set; }
        public virtual DesignTask DesignTask { get; set; }
    }
}
