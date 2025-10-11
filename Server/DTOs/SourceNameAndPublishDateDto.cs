using System;
using Newtonsoft.Json;

namespace Server.DTOs;

public class SourceNameAndPublishDateDto
{
  public required string Id { get; set; }

  [JsonProperty("底本名")]
  public required string Name { get; set; }

  [JsonProperty("底本出版社発行年")]
  public string? PublishDateInfo { get; set; }
}
