namespace Server.Core.Aozora;

public class Aozora
{
  public required string WrittenWorkId { get; set; }
  public required string Title { get; set; }
  public required string TitleReading { get; set; }
  public required string TitleSort { get; set; }
  public string? Subtitle { get; set; }
  public string? SubtitleReading { get; set; }
  public string? OriginalTitle { get; set; }
  public string? ReleaseInfo { get; set; }
  public required string WritingStyle { get; set; }
  public required string WorkCopyright { get; set; }
  public required string AuthorId { get; set; }
  public required string Surname { get; set; }
  public required string SurnameReading { get; set; }
  public required string SurnameSort { get; set; }
  public required string SurnameRomaji { get; set; }
  public string? GivenName { get; set; }
  public string? GivenNameReading { get; set; }
  public string? GivenNameSort { get; set; }
  public string? GivenNameRomaji { get; set; }
  public required string WriterRole { get; set; }
  public string? BirthDate { get; set; }
  public string? DeathDate { get; set; }
  public required string PersonalityRights { get; set; }
  public string? Source { get; set; }
  public string? SourcePublisher { get; set; }
  public string? SourcePublishDate { get; set; }
  public string? OriginalSource { get; set; }
  public string? OriginalSourcePublisher { get; set; }
  public string? OriginalSourcePublishDate { get; set; }
  public string? Source2 { get; set; }
  public string? SourcePublisher2 { get; set; }
  public string? SourcePublishDate2 { get; set; }
  public string? OriginalSource2 { get; set; }
  public string? OriginalSourcePublisher2 { get; set; }
  public string? OriginalSourcePublishDate2 { get; set; }
  public required string TextLink { get; set; }
  public required string HTMLLink { get; set; }
}
