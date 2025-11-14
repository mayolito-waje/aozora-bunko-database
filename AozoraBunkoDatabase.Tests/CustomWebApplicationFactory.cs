using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Server.Data;
using Server.Services;

namespace AozoraBunkoDatabase.Tests;

public class CustomWebApplicationFactory<TProgram>
  : WebApplicationFactory<TProgram> where TProgram : class
{
  private readonly SqliteConnection _connection;

  public CustomWebApplicationFactory()
  {
    _connection = new SqliteConnection("DataSource=:memory:");
    _connection.Open();
  }

  protected override void ConfigureWebHost(IWebHostBuilder builder)
  {
    builder.ConfigureServices(services =>
    {
      var dbContextDescriptor = services.SingleOrDefault(
          d => d.ServiceType ==
              typeof(IDbContextOptionsConfiguration<AppDbContext>));

      services.Remove(dbContextDescriptor!);

      services.AddDbContext<AppDbContext>((options) =>
      {
        options.UseSqlite(_connection);
      });

      services.AddSingleton<AozoraDatabaseService>();

      builder.UseEnvironment("Development");
    });
  }

  protected override void Dispose(bool disposing)
  {
    base.Dispose(disposing);
    _connection?.Dispose();
  }
}
