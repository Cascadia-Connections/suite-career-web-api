using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;

namespace SuiteCareers.Models
{
    public class DashboardVM
    {
        /*Snapshot Bar data*/
        public int NewUser { get; set; }    /*done*/
        public int TotalUsers { get; set; } /*done*/
        public int AvgSessionLength { get; set; }
        public int TotalSessions { get; set; }  /*done*/
        public int QuestionsAnswered { get; set; }
        public int NewQuestions { get; set; }

        /*Active info data*/
        public int ActiveUsers { get; set; }
        public int ActiveSessions { get; set; }

        /*List data*/
        public IEnumerable<Session> Sessions { get; set; }
        public IEnumerable<Question> Questions { get; set; }
    }
}
