using System.ComponentModel.DataAnnotations;

namespace SuiteCareers.Models;

public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}

public class Users {
    
    [Key, DataType(DataType.EmailAddress)]
    public string? email { get; set; }
    [Required(ErrorMessage = "Please enter your first name")]
    public string? firstName { get; set; }
    [Required(ErrorMessage = "Please enter your last name")]
    public string? lastName { get; set; }
    [Required(ErrorMessage = "Please enter the city of which you live")]
    public string? city { get; set; }
    [Required(ErrorMessage = "Please Enter the state of which you live")]
    public string? state { get; set; }   
        }