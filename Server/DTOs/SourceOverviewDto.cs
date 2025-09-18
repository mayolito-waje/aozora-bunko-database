using System;
using Newtonsoft.Json;

namespace Server.DTOs;

public class SourceOverviewDto
{
  public required string Id { get; set; }

  [JsonProperty("底本名")]
  public required string Name { get; set; }

  [JsonProperty("底本出版社ID")]
  public string? PublisherId { get; set; }

  [JsonProperty("底本出版社名")]
  public string? PublisherName { get; set; }

  [JsonProperty("底本出版社発行年")]
  public string? PublishDateInfo { get; set; }

  [JsonProperty("底本の親元ID")]
  public string? OriginalSourceId { get; set; }

  [JsonProperty("底本の親元名")]
  public string? OriginalSourceName { get; set; }

  [JsonProperty("底本の親本出版社ID")]
  public string? OriginalSourcePublisherId { get; set; }

  [JsonProperty("底本の親本出版社名")]
  public string? OriginalSourcePublisherName { get; set; }

  [JsonProperty("底本の親本出版社発行年")]
  public string? OriginalSourcePublishDateInfo { get; set; }
}
