using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuiteCareers.Models
{
    public class User
    {
        public long Id { get; set; }
        [Key, DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Please enter your first name")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Please enter the city of which you live")]
        public string? City { get; set; }
        [Required(ErrorMessage = "Please Enter the state of which you live")]
        public string? State { get; set; }
    }
}
