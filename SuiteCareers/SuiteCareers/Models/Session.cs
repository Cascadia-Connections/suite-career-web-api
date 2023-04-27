using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuiteCareers.Models
{
    public class Session
    {
        [Key]
        public long SessionId { get; set; }
        [Required(ErrorMessage = "Please enter the date")]
        public DateTime Date { get; set; }
        [Required]
        public Interview Interview { get; set; }
        public User User { get; set; }

    }
}

