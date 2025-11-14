using Microsoft.Extensions.DependencyInjection;
using Server.Data;
using Server.Services;

namespace AozoraBunkoDatabase.Tests.Helpers;

public class FactoryDbConnection : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly CustomWebApplicationFactory<Program> _factory;

  public FactoryDbConnection(CustomWebApplicationFactory<Program> factory)
  {
    _factory = factory;
  }

  public async Task UseDbContext(Func<AppDbContext, Task> dbAction)
  {
    using var scope = _factory.Services.CreateScope();
    var aozoraDatabaseService = scope.ServiceProvider.GetRequiredService<AozoraDatabaseService>();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    await DbSeed.ReinitializeDb(dbContext, aozoraDatabaseService);
    await dbAction(dbContext);
  }
}
