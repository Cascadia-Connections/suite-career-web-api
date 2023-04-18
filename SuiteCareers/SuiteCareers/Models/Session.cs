using System.ComponentModel.DataAnnotations;

public class Session
{
    [Key]
    public int sessionId { get; set; }
    [Required(ErrorMessage = "Please enter the date")]
    public DateTime date { get; set; }
    [Required]
    public int interviewId { get; set; }

    public string email { get; set; }


}