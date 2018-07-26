using Microsoft.EntityFrameworkCore;

namespace KTB.Models{
    public class KTBContext : DbContext{
        public KTBContext(DbContextOptions<KTBContext>options) : base(options) {}
        
        public DbSet<Users> users { get; set; }
        public DbSet<UserCategory> usersCategory { get; set; }
        public DbSet<UserChat> usersChat { get; set; }
        public DbSet<UserAnswer> userAnswer { get; set; }
        public DbSet<Chats> chat { get; set; }
        public DbSet<Questions> questions { get; set; }
        public DbSet<Games> games { get; set; }
        public DbSet<GameCategory> gameCategory { get; set; }
        public DbSet<Categories> categories { get; set; }
        public DbSet<Answers> answers { get; set; }
        
    }
}