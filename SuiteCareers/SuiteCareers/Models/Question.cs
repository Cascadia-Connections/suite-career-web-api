using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuiteCareers.Models
{
    public class Question
    {
        [Key]
        public long questionId { get; set; }

        [Required]
        public string? question { get; set; }
    }
}

