namespace AozoraBunkoDatabase.Tests;

public class FactoryFixture : IAsyncLifetime
{
  public PostgresTestDatabase TestDb;
  public CustomWebApplicationFactory<Program> Factory { get; private set; } = default!;

  public FactoryFixture()
  {
    TestDb = new PostgresTestDatabase();
  }

  public async Task InitializeAsync()
  {
    await TestDb.InitializeAsync();
    Factory = new CustomWebApplicationFactory<Program>(TestDb.ConnectionString);
  }

  public async Task DisposeAsync()
  {
    await TestDb.DisposeAsync();
  }
}
