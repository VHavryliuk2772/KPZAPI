namespace Domain.Models
{
    public class Employee : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<EmployeeRole> EmployeeRoles { get; set; }
        public virtual List<EmployeeProjectTask> EmployeeProjectTasks { get; set; }
    }
}
