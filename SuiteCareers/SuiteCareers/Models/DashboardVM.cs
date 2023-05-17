using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SuiteCareers.Models
{
    public class DashboardVM
    {
        /*Snapshot Bar data*/
        public int NewUser { get; set; }    /*done*/
        public int TotalUsers { get; set; } /*done*/
        public int AvgSessionLength { get; set; }
        public int TotalSessions { get; set; }
        public int QuestionsAnswered { get; set; }
        public int NewQuestions { get; set; }


        /*public IEnumerable<User>? Users { get; set; }
        public IEnumerable<Session>? Sessions { get; set; }
        public IEnumerable<Response>? Responses { get; set; }
        public IEnumerable<Question>? Questions { get; set; }
        public IEnumerable<Interview>? Interviews { get; set; }*/
    }
}
