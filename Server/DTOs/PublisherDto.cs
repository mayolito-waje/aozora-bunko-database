using Newtonsoft.Json;

namespace Server.DTOs;

public class PublisherDto
{
  public string Id { get; set; } = Guid.NewGuid().ToString();
  public required string Name { get; set; }
}
