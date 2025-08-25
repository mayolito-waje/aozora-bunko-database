using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
  public DbSet<Author> Authors { get; set; }
  public DbSet<User> Users { get; set; }
}
