using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuiteCareers.Models
{
    public class UserDescription
    {
        [Key]
        public long DescriptionId { get; set; }
        
        public enum EducationLevel {
            MiddleSchool,
            HighSchool,
            Undergraduate,
            Graduate,
            Doctorate
        }

        [Required]
        public string WorkExperience { get; set; }
        [Required]
        public string UserJob { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public long UserId { get; set; }
        public User? User { get; set; }
        public enum Improvements
        {
            InterviewQuestions
        }
        public enum Interests
        {
            Math,
            ComputerProgramming,
            Photography,
            Economics,
            Banking
        }

    }
}

