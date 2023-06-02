using System.ComponentModel.DataAnnotations;
using SuiteCareers.Models;

namespace SuiteCareers.ViewModels
{
    public class SessionsVM
    {
        public IEnumerable<Session> Sessions { get; set; }
        public long SessionId { get; set; }
        [Required(ErrorMessage = "Please enter the date")]
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public ICollection<User> User { get; set; }
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Please enter the city of which you live")]
        public string? UserSortParm { get; set; }
        public string? DateSortParm { get; set; }
        public string? TimeSortParm { get; set; }
        public string? SessionIDSortParm { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? Term { get; set; }
        public string? OrderBy { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
    }
}
