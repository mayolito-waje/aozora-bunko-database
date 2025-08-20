using Microsoft.EntityFrameworkCore;

namespace Server.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
  public DbSet<Author> Authors { get; set; }
}
