using ViewModels.BaseDTOs;

namespace ViewModels.CustomerDTOs
{
    public class ShortCustomerDTO : BaseIdDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
