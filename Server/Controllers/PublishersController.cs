using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.DTOs;
using Server.Extensions;
using X.PagedList.Extensions;

namespace Server.Controllers
{
  public class PublishersController(AppDbContext dbContext) : ControllerProvider
  {
    [HttpGet]
    public async Task<IActionResult> RetrievePublishers(int? page, int? pageSize)
    {
      var publishers = await dbContext.Publishers.Select(
          p => new PublisherDto() { Id = p.Id, Name = p.Name }
      ).ToListAsync();

      return Ok(publishers.ToPagedList(page ?? 1, pageSize ?? 25));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> RetrievePublisherById(string id, int? sourcePage, int? sourcePageSize)
    {
      var publisher = await dbContext.Publishers.FindAsync(id);

      if (publisher == null)
        return NotFound();

      var sources = await dbContext.Sources
          .Where(s => s.PublisherId == publisher.Id)
          .Select(s => s.NameAndPublishDateDto())
          .ToListAsync();

      var sourcesList = sources.ToPagedList(sourcePage ?? 1, sourcePageSize ?? 25);

      return Ok(new
      {
        publisher.Id,
        publisher.Name,
        sources = sourcesList
      });
    }
  }
}
