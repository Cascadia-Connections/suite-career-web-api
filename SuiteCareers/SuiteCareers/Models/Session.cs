using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuiteCareers.Models
{
    public class Session
    {
        [Key]
        public long sessionId { get; set; }
        [Required(ErrorMessage = "Please enter the date")]
        public DateTime date { get; set; }
        [Required]
        public int InterviewId { get; set; }

        public string Email { get; set; }


    }
}

