using System;
using Newtonsoft.Json;

namespace Server.DTOs;

public class SourceOverviewDto
{
  public required string Id { get; set; }
  public required string Name { get; set; }
  public string? PublisherId { get; set; }
  public string? PublisherName { get; set; }
  public string? PublishDateInfo { get; set; }
  public string? OriginalSourceId { get; set; }
  public string? OriginalSourceName { get; set; }
  public string? OriginalSourcePublisherId { get; set; }
  public string? OriginalSourcePublisherName { get; set; }
  public string? OriginalSourcePublishDateInfo { get; set; }
}
