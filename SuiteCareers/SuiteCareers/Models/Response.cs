using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuiteCareers.Models
{
    public class Response
    {
        [Key]
        public long responseId { get; set; }
        public long response { get; set; }

        public long questionId { get; set; }
    }
}

