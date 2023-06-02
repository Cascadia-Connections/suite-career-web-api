using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuiteCareers.Models
{
    public class Session
    {
        [Key]
        public long SessionId { get; set; }
        public DateTime StartDate { get; set; }
        public long UserId { get; set; }
        public long InterviewId { get; set; }
        public Interview Interview { get; set; }
        public User User { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

