using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuiteCareers.Models
{
    public class Response
    {
        [Key]
        public long ResponseId { get; set; }
        public string? UserResponse { get; set; }

        public long QuestionId { get; set; }

    }
}

