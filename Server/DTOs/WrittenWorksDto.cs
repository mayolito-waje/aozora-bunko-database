using Newtonsoft.Json;

namespace Server.DTOs.WrittenWorks;

public class WrittenWorksDto
{
  public required string Id { get; set; }
  public required string Title { get; set; }
  public required string TitleReading { get; set; }
  public required string TitleSort { get; set; }
  public string? Subtitle { get; set; }
  public string? SubtitleReading { get; set; }
  public string? OriginalTitle { get; set; }
  public string? ReleaseInfo { get; set; }
  public string? WritingStyle { get; set; }
  public bool WorkCopyright { get; set; } = false;
  public AuthorDto? Author { get; set; }
  public string? WriterRole { get; set; }
  public SourceOverviewDto? Source { get; set; }
  public SourceOverviewDto? Source2 { get; set; }
  public required string TextLink { get; set; }
  public required string HTMLLink { get; set; }
}
