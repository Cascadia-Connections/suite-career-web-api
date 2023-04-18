using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuiteCareers.Models
{
    
        public class User
        {

            [Key, DataType(DataType.EmailAddress)]
            public string? Email { get; set; }
            
            public string? FirstName { get; set; }
            
            public string? LastName { get; set; }
            
            public string? City { get; set; }
            
            public string? State { get; set; }
        }

     

        

        
            
        



    }

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
