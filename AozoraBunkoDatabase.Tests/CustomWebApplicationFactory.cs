using System.Data.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Server.Data;

namespace AozoraBunkoDatabase.Tests;

public class CustomWebApplicationFactory<TProgram>
  : WebApplicationFactory<TProgram> where TProgram : class
{
  protected override void ConfigureWebHost(IWebHostBuilder builder)
  {
    builder.ConfigureServices(services =>
    {
      var dbContextDescriptor = services.SingleOrDefault(
          d => d.ServiceType ==
              typeof(IDbContextOptionsConfiguration<AppDbContext>));

      services.Remove(dbContextDescriptor!);

      services.AddSingleton<DbConnection>(container =>
      {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        return connection;
      });

      services.AddDbContext<AppDbContext>((container, options) =>
      {
        var connection = container.GetRequiredService<DbConnection>();
        options.UseSqlite();
      });

      builder.UseEnvironment("Development");
    });
  }
}
