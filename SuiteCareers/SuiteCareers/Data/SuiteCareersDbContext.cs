using Microsoft.EntityFrameworkCore;
using SuiteCareers.Models;
namespace SuiteCareers.Data

{
    public class SuiteCareersDbContext : DbContext
    {
        public SuiteCareersDbContext(DbContextOptions<SuiteCareersDbContext> options) : base(options)
        { }

        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserDescription> UserDescriptions { get; set; }

    }
}

