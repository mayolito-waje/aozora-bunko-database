using Server.DTOs.WrittenWorks;
using Server.Models;

namespace Server.Extensions;

public static class WrittenWorkExtensions
{
  public static WrittenWorksDto ToDto(this WrittenWork work)
  {
    return new WrittenWorksDto()
    {
      Id = work.Id,
      Title = work.Title,
      TitleReading = work.TitleReading,
      TitleSort = work.TitleSort,
      Subtitle = work.Subtitle,
      SubtitleReading = work.SubtitleReading,
      OriginalTitle = work.OriginalTitle,
      ReleaseInfo = work.ReleaseInfo,
      WorkCopyright = work.WorkCopyright,
      Author = work.Author?.ToDto(),
      WriterRole = work.WriterRole?.Role,
      WritingStyle = work.WritingStyle?.Style,
      Source = work.Source?.OverviewDto(),
      Source2 = work.Source2?.OverviewDto(),
      TextLink = work.TextLink,
      HTMLLink = work.HTMLLink,
    };
  }
}
