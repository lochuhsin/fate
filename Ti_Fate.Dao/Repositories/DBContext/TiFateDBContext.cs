using Microsoft.EntityFrameworkCore;
using Ti_Fate.Dao.Model;

namespace Ti_Fate.Dao.Repositories.DBContext
{
    public class TiFateDbContext : DbContext
    {
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<Welfare> Welfare { get; set; }
        public DbSet<MeetUp> MeetUp { get; set; }
        public DbSet<ClubsInfo> ClubsInfo { get; set; }
        public DbSet<Clubs> Clubs { get; set; }
        public DbSet<ExternalInfo> ExternalInfo { get; set; }
        public DbSet<Important> Important { get; set; }
        public DbSet<JobsInfo> JobsInfo { get; set; }
        public TiFateDbContext(DbContextOptions<TiFateDbContext> options)
            : base(options)
        { }
    }
}
