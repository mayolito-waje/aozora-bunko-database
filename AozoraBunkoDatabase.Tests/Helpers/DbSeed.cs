using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Services;

namespace AozoraBunkoDatabase.Tests.Helpers;

public static class DbSeed
{
  public static async Task InitializeDb(AppDbContext dbContext, AozoraDatabaseService aozoraDatabaseService)
  {
    await aozoraDatabaseService.PopulateAozoraDatabase("Helpers/aozora_seed.csv");
    await dbContext.SaveChangesAsync();
  }

  public static async Task ReinitializeDb(AppDbContext dbContext, AozoraDatabaseService aozoraDatabaseService)
  {
    await dbContext.Database.MigrateAsync();

    dbContext.Sources.RemoveRange(dbContext.Sources);
    dbContext.Publishers.RemoveRange(dbContext.Publishers);
    dbContext.WriterRoles.RemoveRange(dbContext.WriterRoles);
    dbContext.WritingStyles.RemoveRange(dbContext.WritingStyles);
    dbContext.WrittenWorks.RemoveRange(dbContext.WrittenWorks);
    dbContext.Authors.RemoveRange(dbContext.Authors);

    await dbContext.SaveChangesAsync();
    await InitializeDb(dbContext, aozoraDatabaseService);
  }
}
