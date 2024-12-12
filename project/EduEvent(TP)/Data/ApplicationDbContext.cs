using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EduEvent.Models;


namespace EduEvent.Data;

public class ApplicationDbContext : IdentityDbContext<Student>
{

    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Event>Events { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<IdentityRole>(e => e.Property(m => m.Id).HasMaxLength(100));
        builder.Entity<Student>(e => e.Property(m => m.Id).HasMaxLength(100));
        builder.Entity<IdentityUserLogin<string>>(ul =>
        {
            ul.Property(u => u.UserId).HasMaxLength(100);
            ul.Property(u => u.LoginProvider).HasMaxLength(100);
            ul.Property(u => u.ProviderKey).HasMaxLength(100);
        });
        builder.Entity<IdentityUserToken<string>>(ul =>
        {
            ul.Property(u => u.UserId).HasMaxLength(50);
            ul.Property(u => u.LoginProvider).HasMaxLength(100);
            ul.Property(u => u.Name).HasMaxLength(100);
            //ul.Property(u => u.Value).HasMaxLength(100);
        });
 
        // builder.Entity<IdentityUserRole<string>>(entity =>
        //     {
        //         entity.HasNoKey();
        //         entity.HasData(UserRoles);
        //     });
    }
}