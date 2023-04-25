using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuiteCareers.Models
{
    public class UserDescription
    {
        [Key]
        public long DescriptionId { get; set; }
        [Required(ErrorMessage = "Please enter your educational level")]
        public string EducationLevel { get; set; }
        [Required(ErrorMessage = "Please enter your work experience")]
        public string WorkExperience { get; set; }
        [Required(ErrorMessage = "Please enter your job description")]
        public string UserJob { get; set; }
        [Required(ErrorMessage = "Please enter the date")]
        public DateTime Date { get; set; }
        public long UserId { get; set; }


    }
}

