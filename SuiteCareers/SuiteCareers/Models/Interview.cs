using System.ComponentModel.DataAnnotations;


public class Interview
{
    [Key]
    public int interviewId { get; set; }


    [Required]
    public int questionId { get; set; }


}