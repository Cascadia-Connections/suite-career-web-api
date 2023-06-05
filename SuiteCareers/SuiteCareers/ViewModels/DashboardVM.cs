using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using SuiteCareers.Models;

namespace SuiteCareers.ViewModels
{
    public class DashboardVM
    {
        /*Snapshot Bar data*/
        public int NewUser { get; set; }    /*done*/
        public int TotalUsers { get; set; } /*done*/
        public double AvgSessionLength { get; set; }
        public int TotalSessions { get; set; }  /*done*/
        public int QuestionsAnswered { get; set; }
        public int NewQuestions { get; set; } /*done*/

        /*Active info data*/
        public int ActiveUsers { get; set; }
        public int ActiveSessions { get; set; } /*done*/

        public IEnumerable<Session>? RecentSessions { get; set; }
        public IEnumerable<Question>? TopQuestions { get; set; }

        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
    }
}
