namespace Domain.Models
{
    public class EmployeeRole : BaseModel
    {
        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int? RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
