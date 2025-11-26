using Microsoft.Extensions.DependencyInjection;
using Server.Data;

namespace AozoraBunkoDatabase.Tests.Helpers;

public class FactoryDbConnection
{
  private readonly CustomWebApplicationFactory<Program> _factory;

  public FactoryDbConnection(CustomWebApplicationFactory<Program> factory)
  {
    _factory = factory;
  }

  public async Task UseDbContext(Func<AppDbContext, Task> dbAction)
  {
    using var scope = _factory.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    await dbAction(dbContext);
  }
}
