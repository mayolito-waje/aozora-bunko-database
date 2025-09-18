using Newtonsoft.Json;

namespace Server.DTOs.WrittenWorks;

public class WrittenWorksDto
{
  public required string Id { get; set; }

  [JsonProperty("作品名")]
  public required string Title { get; set; }

  [JsonProperty("作品名読み")]
  public required string TitleReading { get; set; }

  [JsonProperty("ソート用読み")]
  public required string TitleSort { get; set; }

  [JsonProperty("副題")]
  public string? Subtitle { get; set; }

  [JsonProperty("副題読み")]
  public string? SubtitleReading { get; set; }

  [JsonProperty("原題")]
  public string? OriginalTitle { get; set; }

  [JsonProperty("初出")]
  public string? ReleaseInfo { get; set; }

  [JsonProperty("文字使い種別")]
  public string? WritingStyle { get; set; }

  [JsonProperty("作品著作権フラグ")]
  public bool WorkCopyright { get; set; } = false;

  [JsonProperty("人物")]
  public AuthorDto? Author { get; set; }

  [JsonProperty("役割フラグ")]
  public string? WriterRole { get; set; }

  [JsonProperty("底本")]
  public SourceOverviewDto? Source { get; set; }

  [JsonProperty("底本2")]
  public SourceOverviewDto? Source2 { get; set; }

  [JsonProperty("テキストファイルURL")]
  public required string TextLink { get; set; }

  [JsonProperty("XHTML/HTMLファイルURL")]
  public required string XHTMLLink { get; set; }
}
