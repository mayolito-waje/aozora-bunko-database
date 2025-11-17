using System;
using Server.DTOs;
using Server.Models;

namespace Server.Interfaces;

public interface IPublishersContext
{
  Task<List<PublisherDto>> GetPublishers();
  Task<Publisher?> GetPublisherById(string id);
  Task<PublisherWithSourcesDto?> IncludeSources(Publisher publisher, int? sourcePage, int? sourcePageSize);
}
