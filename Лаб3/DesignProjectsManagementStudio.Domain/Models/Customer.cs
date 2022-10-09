using AutoMapper;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Customer : BaseModel
    {
        public virtual List<Project> Projects { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
