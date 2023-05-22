using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using SuiteCareers.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;

namespace SuiteCareers.ViewModels
{
    public class RecentSession
    
     {
       /* public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long CompletionTime { get; set; }
        public long Duration { get; set; }*/

        public IEnumerable<Session>? RecentSessions { get; set; }

    }

}
