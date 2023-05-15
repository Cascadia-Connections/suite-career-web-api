using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SuiteCareers.Models
{
    public class DashboardVM
    {
        public IEnumerable<User>? Users { get; set; }
        public IEnumerable<Session>? Sessions { get; set; }
        public IEnumerable<Response>? Responses { get; set; }
        public IEnumerable<Question>? Questions { get; set; }
        public IEnumerable<Interview>? Interviews { get; set; }
    }
}
