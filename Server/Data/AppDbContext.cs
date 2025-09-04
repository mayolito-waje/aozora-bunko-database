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
}
