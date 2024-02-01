using Logan_Kaas_MVC_WebServerAppDev.Entities;
using Microsoft.EntityFrameworkCore;

namespace Logan_Kaas_MVC_WebServerAppDev.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) 
        {

        }

        // LOGAN KAAS - WEEK 4 ASSIGNMENT
        public DbSet<Hobbies> Hobbies { get; set; }
        public DbSet<FavoriteBreakfast> FavoriteBreakfast { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // LOGAN KAAS - WEEK 4 ASSIGNMENT
            modelBuilder.Entity<Hobbies>().HasKey(x => new { x.HobbyId });
            modelBuilder.Entity<FavoriteBreakfast>().HasKey(x => new { x.FavoriteBreakfastId });
        }
    }
}
