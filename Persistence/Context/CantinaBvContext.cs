using Domain;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Persistence.Context;

public class CantinaBvContext : DbContext
{

    public CantinaBvContext(DbContextOptions<CantinaBvContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        //modelBuilder.Entity<User>().ToTable("Users");
        //modelBuilder.Entity<User>().HasOne(s => s.Role)
        //    .WithMany(g => g.Users)
        //    .HasForeignKey(s => s.RoleId);

        //modelBuilder.Entity<Role>().HasMany<User>(g => g.Users)
        //  .WithRequired(s => s.Role)
        //  .HasForeignKey(s => s.RoleId);
    }
}

