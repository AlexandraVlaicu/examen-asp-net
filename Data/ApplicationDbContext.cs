using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;
using examen.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace examen.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }
    public DbSet<Evenimente> Ev { get; set; }
    public DbSet<Participanti> P { get; set; }
    public DbSet<EvOrg> EVo { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<EvOrg>()
        .HasKey(dc => dc.idevo);
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Evenimente>()
        .HasKey(dc => dc.idev);
        // Relația many-to-many 
        modelBuilder.Entity<Evenimente>()
            .HasMany(e => e.P)
            .WithMany(e => e.Ev);

        // Relația one-to-many î
        modelBuilder.Entity<Evenimente>()
            .HasMany(c => c.EvOrgs)
            .WithOne(dc => dc.Evenimente)
            .OnDelete(DeleteBehavior.Cascade);

        // Relația many-to-one între DetaliuComanda și Produs
        modelBuilder.Entity<EvOrg>()
            .HasOne(dc => dc.Participanti)
            .WithMany(c => c.EvOrgs);

    }
}