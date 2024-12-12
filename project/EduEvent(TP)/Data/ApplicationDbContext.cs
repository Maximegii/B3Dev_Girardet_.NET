using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EduEvent.Models;

namespace EduEvent.Data;

public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
{
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Event> Events { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(e =>
            {
                e.Property(u => u.Firstname).IsRequired().HasMaxLength(50);
                e.Property(u => u.Lastname).IsRequired().HasMaxLength(50);
            });
        }

    // protected override void OnModelCreating(ModelBuilder builder)
    // {
    //     base.OnModelCreating(builder);

        
    //     builder.Entity<IdentityUser>()
    //         .HasDiscriminator<string>("Discriminator")
    //         .HasValue<IdentityUser>("IdentityUser")
    //         .HasValue<Teacher>("Teacher");

        
    //     builder.Entity<Event>(e =>
    //     {
    //         e.HasKey(ev => ev.Id);
    //         e.Property(ev => ev.Title).IsRequired().HasMaxLength(100);
    //         e.Property(ev => ev.Description).IsRequired().HasMaxLength(500);
    //         e.Property(ev => ev.Location).IsRequired().HasMaxLength(100);
    //     });

    //     builder.Entity<Teacher>(e =>
    //     {
    //         e.Property(t => t.Firstname).IsRequired().HasMaxLength(50);
    //         e.Property(t => t.Lastname).IsRequired().HasMaxLength(50);
    //     });
    // }
}
