using System.ComponentModel.DataAnnotations;

public class UserDescription
{
    [Key]
    public int DescriptionId { get; set; }
    [Required(ErrorMessage = "Please enter your educational level")]
    public string EducationLevel { get; set; }
    [Required(ErrorMessage = "Please enter your work experience")]
    public string WorkExperience { get; set; }
    [Required(ErrorMessage = "Please enter your job description")]
    public string UserJob { get; set; }
    [Required(ErrorMessage = "Please enter the date")]
    public DateTime date { get; set; }
    //How to add foreigh key to this class?
    //[DataType(DataType.EmailAddress)]
    //public string? Email { get; set; }

}
