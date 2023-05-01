using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuiteCareers.Models
{

    public class User
    {
        [Key]
        public long UserId { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? State { get; set; }
        public UserDescription UserDescription { get; set; }
        public ICollection<Session> Sessions { get; set; }
    }

}
     

        

 

           