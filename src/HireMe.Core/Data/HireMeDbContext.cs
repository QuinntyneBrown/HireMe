using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using HireMe.Core.Models;

namespace HireMe.Core.Data
{
    public class HireMeDbContext : DbContext, IHireMeDbContext
    {
        public HireMeDbContext(DbContextOptions options)
            : base(options) { }

        public static readonly ILoggerFactory ConsoleLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public DbSet<Answer> Answers { get; private set; }
        public DbSet<Candidate> Candidates { get; private set; }
        public DbSet<DigitalAsset> DigitalAssets { get; private set; }
        public DbSet<Employeer> Employeers { get; private set; }
        public DbSet<Opportunity> Opportunities { get; private set; }
        public DbSet<Question> Questions { get; private set; }
        public DbSet<Role> Roles { get; private set; }
        public DbSet<User> Users { get; private set; }
        public DbSet<Video> Videos { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
