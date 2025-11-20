using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models;

public class WrittenWork
{
  public required string Id { get; set; }
  public required string Title { get; set; }
  public required string TitleReading { get; set; }
  public required string TitleSort { get; set; }
  public string? Subtitle { get; set; }
  public string? SubtitleReading { get; set; }
  public string? OriginalTitle { get; set; }
  public string? ReleaseInfo { get; set; }
  public required string WritingStyleId { get; set; }
  public WritingStyle? WritingStyle { get; set; }
  public bool WorkCopyright { get; set; }
  public required string AuthorId { get; set; }
  public Author? Author { get; set; }
  public required string WriterRoleId { get; set; }
  public WriterRole? WriterRole { get; set; }
  public string? SourceId { get; set; }
  public Source? Source { get; set; }
  public string? Source2Id { get; set; }
  public Source? Source2 { get; set; }
  public required string TextLink { get; set; }
  public required string HTMLLink { get; set; }
}
