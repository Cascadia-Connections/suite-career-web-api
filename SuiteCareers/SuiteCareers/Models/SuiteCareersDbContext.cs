using System;
using Microsoft.EntityFrameworkCore;
namespace SuiteCareers.Models
{
	public class SuiteCareersDbContext:DbContext
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

