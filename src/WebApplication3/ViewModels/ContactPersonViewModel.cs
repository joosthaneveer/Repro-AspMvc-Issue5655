using System.ComponentModel.DataAnnotations;

namespace WebApplication3.ViewModels
{
    public class ContactPersonViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(25)]
        [RegularExpression(@"^[0-9,\-,+]+$", ErrorMessage = "Not a valid phone number, only numbers, + and - allowed.")]
        public string PhoneNumber { get; set; }
    }
}
