using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuiteCareers.Models
{
    public class User
    {
<<<<<<< HEAD

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
=======
        public class User
        {

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

>>>>>>> 9d9c8f3f1e8de0e97e3c5904a2de4599c23c181d
    }

}
