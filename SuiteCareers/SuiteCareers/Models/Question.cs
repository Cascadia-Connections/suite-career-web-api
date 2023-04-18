using System.ComponentModel.DataAnnotations;

public class Question
{
    [Key]
    public int questionId { get; set; }

    [Required]
    public string? question { get; set; }
}

