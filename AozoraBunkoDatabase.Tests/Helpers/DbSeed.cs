using System.IO.Compression;
using System.Net;
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Services;

namespace AozoraBunkoDatabase.Tests.Helpers;

public static class DbSeed
{
  public static async Task<MemoryStream> CreateMockSeederStream()
  {
    var csvPath = "Helpers/aozora_seed.csv";
    var csvBytes = await File.ReadAllBytesAsync(csvPath);

    var zipStream = new MemoryStream();

    using (var archive = new ZipArchive(zipStream, ZipArchiveMode.Create, leaveOpen: true))
    {
      var entry = archive.CreateEntry("aozora_seed.csv", CompressionLevel.NoCompression);

      using (var entryStream = entry.Open())
      {
        await entryStream.WriteAsync(csvBytes);
      }
    }

    zipStream.Position = 0;
    return zipStream;
  }

  public static async Task InitializeDb(AppDbContext dbContext, AozoraDatabaseService aozoraDatabaseService)
  {
    var archiveStream = await CreateMockSeederStream();
    using var archive = new ZipArchive(archiveStream, ZipArchiveMode.Read);

    await aozoraDatabaseService.PopulateAozoraDatabase(archive.Entries[0]);
    await dbContext.SaveChangesAsync();
  }

  public static async Task ReinitializeDb(AppDbContext dbContext, AozoraDatabaseService aozoraDatabaseService)
  {
    await dbContext.Database.MigrateAsync();

    await dbContext.Database.ExecuteSqlRawAsync(
      "TRUNCATE TABLE \"Sources\", \"Publishers\", \"WriterRoles\", \"WritingStyles\", \"WrittenWorks\", \"Authors\" RESTART IDENTITY CASCADE;"
    );

    await InitializeDb(dbContext, aozoraDatabaseService);
  }
}
