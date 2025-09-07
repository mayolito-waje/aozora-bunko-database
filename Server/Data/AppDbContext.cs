using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
  public DbSet<Author> Authors { get; set; }
  public DbSet<WrittenWork> WrittenWorks { get; set; }
  public DbSet<WritingStyle> WritingStyles { get; set; }
  public DbSet<WriterRole> WriterRoles { get; set; }
  public DbSet<Source> Sources { get; set; }
  public DbSet<Publisher> Publishers { get; set; }

  public DbSet<User> Users { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<WrittenWork>()
      .HasOne(x => x.Source)
      .WithMany(y => y.WrittenWorks)
      .HasForeignKey(x => x.SourceId)
      .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<WrittenWork>()
      .HasOne(x => x.Source2)
      .WithMany(y => y.WrittenWorks2)
      .HasForeignKey(x => x.Source2Id)
      .OnDelete(DeleteBehavior.Restrict);
  }
}
