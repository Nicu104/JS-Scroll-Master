using Microsoft.EntityFrameworkCore;

namespace KTB.Models{
    public class KTBContext : DbContext{
        public KTBContext(DbContextOptions<KTBContext>options) : base(options) {}
        
        // public DbSet<User> users { get; set; }
        // public DbSet<Activiti> activities {get; set; }
        // public DbSet<UserActivity> usersActivity{ get; set; }
        
    }
}