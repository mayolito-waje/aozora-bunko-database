using System;
using X.PagedList;

namespace Server.DTOs;

public class PublisherWithSourcesDto
{
  public required string Id { get; set; }
  public required string Name { get; set; }
  public IPagedList<SourceNameAndPublishDateDto>? Sources { get; set; }
}
