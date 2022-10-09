using ViewModels.BaseDTOs;

namespace ViewModels.CustomerDTOs
{
    public class UpdateCreateCustomerDTO : BaseIdDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
