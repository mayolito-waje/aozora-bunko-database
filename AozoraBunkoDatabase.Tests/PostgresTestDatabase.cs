using Testcontainers.PostgreSql;

namespace AozoraBunkoDatabase.Tests;

public class PostgresTestDatabase : IAsyncLifetime
{
  private readonly PostgreSqlContainer Container;
  public string ConnectionString => Container.GetConnectionString();

  public PostgresTestDatabase()
  {
    Container = new PostgreSqlBuilder()
                    .WithImage("postgres:18.1")
                    .Build();
  }

  public async Task InitializeAsync()
  {
    await Container.StartAsync();
  }

  public async Task DisposeAsync()
  {
    await Container.DisposeAsync();
  }
}
