using Newtonsoft.Json;

namespace Server.DTOs;

public class PublisherDto
{
  public string Id { get; set; } = Guid.NewGuid().ToString();

  [JsonProperty("出版社名")]
  public required string Name { get; set; }
}
