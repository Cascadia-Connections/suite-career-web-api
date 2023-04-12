using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuiteCareers.Models
{
    public class Interview
    {
        [Key]
        public int interviewId { get; set; }


        [Required]
        public int questionId { get; set; }

    }
}

