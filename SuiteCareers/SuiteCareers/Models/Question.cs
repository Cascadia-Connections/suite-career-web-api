using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuiteCareers.Models
{
    public class Question
    {
        [Key]
        public long QuestionId { get; set; }
        [Required]
        public string? QuestionContent { get; set; }
        public long InterviewId { get; set; }
        public Interview? Interview { get; set; }
        public bool? UserGenerated { get; set; }
        public DateTime? CreateDate { get; set; }

    }
}

