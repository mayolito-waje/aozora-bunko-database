using System;
using Newtonsoft.Json;

namespace Server.DTOs;

public class SourceNameAndPublishDateDto
{
  public required string Id { get; set; }
  public required string Name { get; set; }
  public string? PublishDateInfo { get; set; }
}
