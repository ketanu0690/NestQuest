using Microsoft.EntityFrameworkCore;
using NestQuestBackEnd.Domain.Models.Entities;


namespace NestQuestBackEnd.DAL.DBContext
{
    public class DbServiceContext : DbContext
    {
        public DbServiceContext(DbContextOptions<DbServiceContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey("UserId");
            modelBuilder.Entity<Property>().HasKey("PropertyId");
            modelBuilder.Entity<UserFavorite>().HasKey("UserId");
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
    }
}
