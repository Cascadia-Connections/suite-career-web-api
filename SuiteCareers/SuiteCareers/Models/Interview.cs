using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuiteCareers.Models
{
    public class Interview
    {
        [Key]
        public long interviewId { get; set; }


        [Required]
        public long questionId { get; set; }


    }
}

