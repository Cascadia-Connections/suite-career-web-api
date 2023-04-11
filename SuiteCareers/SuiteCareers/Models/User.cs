using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuiteCareers.Models
{
    public class UserInfo
    {
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

        public class UserDescription
        {
            [Key]
            public int DescriptionId {get; set;}
            [Required(ErrorMessage = "Please enter your educational level")]
            public string EducationLevel { get; set;}
            [Required(ErrorMessage = "Please enter your work experience")]
            public string WorkExperience { get; set; }
            [Required(ErrorMessage = "Please enter your job description")]
            public string UserJob { get; set;}
            [Required(ErrorMessage = "Please enter the date")]
            public DateTime date { get; set; }
            //How to add foreigh key to this class?
            //[DataType(DataType.EmailAddress)]
            //public string? Email { get; set; }

        }
        public class Session
        {
            [Key]
            public int sessionId { get; set; }
            [Required(ErrorMessage = "Please enter the date")]
            public DateTime date { get; set; }
            [Required]
            public int interviewId { get; set; }

            public string email { get; set; }

            
        }

        public class Interview
        {
            [Key]
            public int interviewId { get; set; }


            [Required]
            public int questionId { get; set; }


        }

        public class Question
        {
            [Key]
            public int questionId { get; set; }

            [Required]
            public string? question { get; set; }
        }
            
        public class Response
        {
            [Key]
            public int responseId { get; set; }
            public int response { get; set; }
            
            public int questionId { get; set; }
        }



    }
}
