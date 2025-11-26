using AozoraBunkoDatabase.Tests.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Respawn;
using Server.Data;
using Server.Services;

namespace AozoraBunkoDatabase.Tests.IntegrationTests;

public class BaseIntegrationTest : IClassFixture<FactoryFixture>, IAsyncLifetime
{
  private readonly FactoryFixture _factoryFixture;
  protected readonly HttpClient Client;
  protected readonly CustomWebApplicationFactory<Program> Factory;
  protected readonly FactoryDbConnection Connection;

  public BaseIntegrationTest(FactoryFixture factory)
  {
    _factoryFixture = factory;

    Factory = _factoryFixture.Factory!;
    Client = Factory.CreateClient(new WebApplicationFactoryClientOptions
    {
      AllowAutoRedirect = false
    });
    Connection = new FactoryDbConnection(Factory);
  }

  public async Task InitializeAsync()
  {
    using (var conn = new NpgsqlConnection(_factoryFixture.TestDb.ConnectionString))
    {
      await conn.OpenAsync();

      var respawner = await Respawner.CreateAsync(
        conn,
        new RespawnerOptions { SchemasToInclude = ["public", "__EFMigrationsHistory"], DbAdapter = DbAdapter.Postgres }
      );
      await respawner.ResetAsync(conn);
    }

    using var scope = Factory.Services.CreateScope();
    var aozoraDatabaseService = scope.ServiceProvider.GetRequiredService<AozoraDatabaseService>();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    await DbSeed.InitializeDb(dbContext, aozoraDatabaseService);
  }

  public Task DisposeAsync()
  {
    // I do not have to call any dispose methods since FactoryFixture handles it already otherwise it will throw another error
    return Task.CompletedTask;
  }
}
