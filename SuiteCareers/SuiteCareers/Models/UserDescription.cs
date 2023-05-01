using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuiteCareers.Models
{
    public class UserDescription
    {
        [Key]
        public long DescriptionId { get; set; }
        [Required]
        public string EducationLevel { get; set; }
        [Required]
        public string WorkExperience { get; set; }
        [Required]
        public string UserJob { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }


    }
}

