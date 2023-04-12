using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuiteCareers.Models
{
    public class Response
    {
        [Key]
        public int responseId { get; set; }
        public int response { get; set; }

        public int questionId { get; set; }
    }
}

