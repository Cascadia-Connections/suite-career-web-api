using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuiteCareers.Models
{
    public class Interview
    {
        [Key]
        public long InterviewId { get; set; }


        [Required]
        public ICollection<Question> Questions { get; set; }

    }
}

