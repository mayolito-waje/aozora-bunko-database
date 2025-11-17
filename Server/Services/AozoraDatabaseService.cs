using System.Globalization;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using Server.Core.Aozora;
using Server.Data;
using Server.Interfaces;
using Server.Models;

namespace Server.Services;

public class AozoraDatabaseService(AppDbContext dbContext) : IAozoraDatabaseService
{
  // private async Task UseDbContext(Func<AppDbContext, Task> action)
  // {
  //   using var scope = scopeFactory.CreateScope();
  //   var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

  //   await action(dbContext);
  // }

  public async Task PopulateAozoraDatabase(string csvPath)
  {
    using var reader = new StreamReader(csvPath);
    using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

    csv.Context.RegisterClassMap<AozoraMap>();
    foreach (var record in csv.GetRecords<Aozora>())
      if (await AddRow(record))
        Console.WriteLine($"Added new row with ID {record.WrittenWorkId}.");
      else
        Console.WriteLine($"Row with ID {record.WrittenWorkId} already exists");
  }

  private async Task<bool> AddRow(Aozora data)
  {
    var author = await dbContext.Authors.FindAsync(data.AuthorId);
    author ??= await AddAuthor(data);

    string? source1 = await HandleSource(new AozoraSourceExtended()
    {
      Source = data.Source,
      SourcePublisher = data.SourcePublisher,
      SourcePublishDate = data.SourcePublishDate,
      OriginalSource = data.OriginalSource,
      OriginalSourcePublisher = data.OriginalSourcePublisher,
      OriginalSourcePublishDate = data.OriginalSourcePublishDate,
    });

    string? source2 = await HandleSource(new AozoraSourceExtended()
    {
      Source = data.Source2,
      SourcePublisher = data.SourcePublisher2,
      SourcePublishDate = data.SourcePublishDate2,
      OriginalSource = data.OriginalSource2,
      OriginalSourcePublisher = data.OriginalSourcePublisher2,
      OriginalSourcePublishDate = data.OriginalSourcePublishDate2,
    });

    var writerRole = await dbContext.WriterRoles.FindAsync(data.WriterRole);
    writerRole ??= await AddWriterRole(data.WriterRole);

    var writingStyle = await dbContext.WritingStyles.FindAsync(data.WritingStyle);
    writingStyle ??= await AddWritingStyle(data.WritingStyle);

    var writtenWork = await dbContext.WrittenWorks.FindAsync(data.WrittenWorkId);
    if (writtenWork != null)
    {
      return false;
    }
    else
    {
      await AddWrittenWork(data, author, source1, source2, writerRole, writingStyle);
      return true;
    }
  }

  private async Task<Author> AddAuthor(Aozora data)
  {
    var newAuthor = new Author()
    {
      Id = data.AuthorId,
      Surname = data.Surname,
      SurnameReading = data.SurnameReading,
      SurnameSort = data.SurnameSort,
      SurnameRomaji = data.SurnameRomaji,
      GivenName = data.GivenName,
      GivenNameReading = data.GivenNameReading,
      GivenNameSort = data.GivenNameSort,
      GivenNameRomaji = data.GivenNameRomaji,
      BirthDate = data.BirthDate,
      DeathDate = data.DeathDate,
      PersonalityRights = data.PersonalityRights == "あり",
    };

    dbContext.Authors.Add(newAuthor);
    await dbContext.SaveChangesAsync();

    return newAuthor;
  }

  private async Task<Publisher> AddPublisher(string publisherName)
  {
    var newPublisher = new Publisher()
    {
      Name = publisherName
    };

    dbContext.Publishers.Add(newPublisher);
    await dbContext.SaveChangesAsync();

    return newPublisher;
  }

  private async Task<Source> AddSource(Source data)
  {
    dbContext.Sources.Add(data);
    await dbContext.SaveChangesAsync();

    return data;
  }

  private async Task<string?> HandleSource(AozoraSourceExtended data)
  {
    Source? source = null;

    Publisher? originalSourcePublisher = null;
    if (!string.IsNullOrEmpty(data.OriginalSourcePublisher))
    {
      originalSourcePublisher = await dbContext.Publishers.SingleOrDefaultAsync(
        x => x.Name == data.OriginalSourcePublisher
      );
      originalSourcePublisher ??= await AddPublisher(data.OriginalSourcePublisher);
    }

    Source? originalSource = null;
    if (!string.IsNullOrEmpty(data.OriginalSource))
    {
      if (originalSourcePublisher != null)
        originalSource = await dbContext.Sources.SingleOrDefaultAsync(
          x => x.Name == data.OriginalSource && x.PublisherId == originalSourcePublisher.Id
        );
      originalSource ??= await AddSource(new Source()
      {
        Name = data.OriginalSource,
        PublisherId = originalSourcePublisher?.Id,
        PublishDateInfo = data.OriginalSourcePublishDate,
      });
    }

    Publisher? sourcePublisher = null;
    if (!string.IsNullOrEmpty(data.SourcePublisher))
    {
      sourcePublisher = await dbContext.Publishers.SingleOrDefaultAsync(
        x => x.Name == data.SourcePublisher
      );
      sourcePublisher ??= await AddPublisher(data.SourcePublisher);
    }

    if (!string.IsNullOrEmpty(data.Source))
    {
      if (sourcePublisher != null)
        source = await dbContext.Sources.SingleOrDefaultAsync(
          x => x.Name == data.Source && x.PublisherId == sourcePublisher.Id
        );
      source ??= await AddSource(new Source()
      {
        Name = data.Source,
        PublisherId = sourcePublisher?.Id,
        PublishDateInfo = data.SourcePublishDate,
        OriginalSourceId = originalSource?.Id,
      });
    }

    return source?.Id;
  }

  private async Task<WriterRole> AddWriterRole(string role)
  {
    var writerRole = new WriterRole() { Role = role };

    dbContext.WriterRoles.Add(writerRole);
    await dbContext.SaveChangesAsync();

    return writerRole;
  }

  private async Task<WritingStyle> AddWritingStyle(string style)
  {
    var writingStyle = new WritingStyle() { Style = style };

    dbContext.WritingStyles.Add(writingStyle);
    await dbContext.SaveChangesAsync();

    return writingStyle;
  }

  private async Task AddWrittenWork(
    Aozora data, Author author, string? source1Id, string? source2Id, WriterRole writerRole, WritingStyle writingStyle
    )
  {
    var newWrittenWork = new WrittenWork()
    {
      Id = data.WrittenWorkId,
      Title = data.Title,
      TitleReading = data.TitleReading,
      TitleSort = data.TitleSort,
      Subtitle = data?.Subtitle,
      SubtitleReading = data?.SubtitleReading,
      OriginalTitle = data?.OriginalTitle,
      ReleaseInfo = data?.ReleaseInfo,
      WritingStyleId = writingStyle.Style,
      WorkCopyright = data?.WorkCopyright == "あり",
      AuthorId = author.Id,
      WriterRoleId = writerRole.Role,
      SourceId = source1Id,
      Source2Id = source2Id,
      TextLink = data?.TextLink ?? string.Empty,
      HTMLLink = data?.HTMLLink ?? string.Empty,
    };

    dbContext.WrittenWorks.Add(newWrittenWork);
    await dbContext.SaveChangesAsync();
  }
}
