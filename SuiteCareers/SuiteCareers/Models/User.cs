using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuiteCareers.Models
{

    public class User
    {
        [Key]
        public long UserId { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public bool? ActivityStatus { get; set; }
        public string? UserJob { get; set; }
        public int? YearsOfExperience { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? EducationLevel { get; set; }
        public string? EducationSpecifics { get; set; }
        public string? Interests { get; set; }
        public string? AreaOfImprovement { get; set; }
        public ICollection<Session>? Sessions { get; set; }

    }

}
     

        

 

           