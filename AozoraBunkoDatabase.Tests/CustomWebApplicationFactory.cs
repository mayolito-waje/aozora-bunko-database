using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Server.Data;
using Server.Services;

namespace AozoraBunkoDatabase.Tests;

public class CustomWebApplicationFactory<TProgram>
  : WebApplicationFactory<TProgram> where TProgram : class
{
  private readonly string _connection;

  public CustomWebApplicationFactory(string connectionString)
  {
    _connection = connectionString;
  }

  protected override void ConfigureWebHost(IWebHostBuilder builder)
  {
    builder.UseEnvironment("Testing");

    builder.ConfigureServices(services =>
    {
      var dbContextDescriptor = services.SingleOrDefault(
          d => d.ServiceType == typeof(IDbContextOptionsConfiguration<AppDbContext>)
      );

      if (dbContextDescriptor != null)
        services.Remove(dbContextDescriptor!);

      services.AddDbContext<AppDbContext>((options) =>
      {
        options.UseNpgsql(_connection);
      });

      services.AddScoped<AozoraDatabaseService>();

      var sp = services.BuildServiceProvider();
      using var scope = sp.CreateScope();
      var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

      dbContext.Database.Migrate();
    });
  }
}