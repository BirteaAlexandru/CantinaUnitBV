using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace CantinaUnitBV.Models
{
    public class UserContext : DbContext
    {
        DbSet<User> _users { get; set; }
        DbSet<Role> _roles { get; set; }

        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasOne(s => s.Role)
                .WithMany(g => g.Users)
                .HasForeignKey(s => s.RoleId);

            //modelBuilder.Entity<Role>().HasMany<User>(g => g.Users)
            //  .WithRequired(s => s.Role)
            //  .HasForeignKey(s => s.RoleId);
        }
    }
  
}
