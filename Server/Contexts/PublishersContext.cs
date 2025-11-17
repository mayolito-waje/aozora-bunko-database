using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.DTOs;
using Server.Extensions;
using Server.Interfaces;
using Server.Models;
using X.PagedList.Extensions;

namespace Server.Contexts;

public class PublishersContext : IPublishersContext
{
  private readonly AppDbContext _dbContext;

  public PublishersContext(AppDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<List<PublisherDto>> GetPublishers()
  {
    var publishers = await _dbContext.Publishers.Select(
      p => new PublisherDto() { Id = p.Id, Name = p.Name }
    ).ToListAsync();

    return publishers;
  }

  public async Task<Publisher?> GetPublisherById(string id)
  {
    var publisher = await _dbContext.Publishers.FindAsync(id);
    return publisher;
  }

  public async Task<PublisherWithSourcesDto?> IncludeSources(Publisher publisher, int? sourcePage, int? sourcePageSize)
  {
    var sources = await _dbContext.Sources
      .Where(s => s.PublisherId == publisher.Id)
      .Select(s => s.NameAndPublishDateDto())
      .ToListAsync();

    var sourcesList = sources.ToPagedList(sourcePage ?? 1, sourcePageSize ?? 25);

    return new PublisherWithSourcesDto()
    {
      Id = publisher.Id,
      Name = publisher.Name,
      Sources = sourcesList
    };
  }
}
