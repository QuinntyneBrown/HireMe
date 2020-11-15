using Microsoft.EntityFrameworkCore;
using HireMe.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace HireMe.Core.Data
{
    public interface IHireMeDbContext
    {
        DbSet<Answer> Answers { get; }
        DbSet<Candidate> Candidates { get; }
        DbSet<DigitalAsset> DigitalAssets { get; }
        DbSet<Employeer> Employeers { get; }
        DbSet<Question> Questions { get; }
        DbSet<Role> Roles { get; }
        DbSet<User> Users { get; }
        DbSet<Video> Videos { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
