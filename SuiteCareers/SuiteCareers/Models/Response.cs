using System.ComponentModel.DataAnnotations;

public class Response
{
    [Key]
    public int responseId { get; set; }
    public int response { get; set; }

    public int questionId { get; set; }
}
