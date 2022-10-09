namespace Domain.Models
{
    public class Role : BaseModel
    {
        public string Name { get; set; }
        public virtual List<EmployeeRole> EmployeeRoles { get; set; }
    }
}
