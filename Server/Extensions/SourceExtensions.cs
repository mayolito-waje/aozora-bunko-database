using System;
using Server.Data;
using Server.DTOs;
using Server.Models;

namespace Server.Extensions;

public static class SourceExtensions
{
  public static SourceOverviewDto OverviewDto(this Source source)
  {
    return new SourceOverviewDto()
    {
      Id = source.Id,
      Name = source.Name,
      PublisherId = source.PublisherId,
      PublisherName = source.Publisher?.Name,
      PublishDateInfo = source.PublishDateInfo,
      OriginalSourceId = source.OriginalSourceId,
      OriginalSourceName = source.OriginalSource?.Name,
      OriginalSourcePublisherId = source.OriginalSource?.PublisherId,
      OriginalSourcePublisherName = source.OriginalSource?.Publisher?.Name,
      OriginalSourcePublishDateInfo = source.OriginalSource?.PublishDateInfo,
    };
  }

  public static SourceNameAndPublishDateDto NameAndPublishDateDto(this Source source)
  {
    return new SourceNameAndPublishDateDto()
    {
      Id = source.Id,
      Name = source.Name,
      PublishDateInfo = source.PublishDateInfo,
    };
  }
}
