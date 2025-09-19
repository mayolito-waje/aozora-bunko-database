using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Extensions;
using X.PagedList.Extensions;

namespace Server.Controllers
{
  public class WrittenWorksController(AppDbContext dbContext) : ControllerProvider
  {
    [HttpGet]
    public async Task<IActionResult> RetrieveWorks([FromQuery(Name = "s")] string? search, string? authorId, int? page, int? pageSize)
    {
      var works = await dbContext.WrittenWorks
          .Where(w =>
              (authorId == null || w.AuthorId == authorId) &&
              (string.IsNullOrEmpty(search) ||
                EF.Functions.Like(w.Title, $"%{search}%") ||
                EF.Functions.Like(w.TitleReading, $"%{search}%") ||
                EF.Functions.Like(w.TitleSort, $"%{search}%")))
          .OrderBy(w => w.TitleSort)
          .ThenBy(w => w.TitleReading)
          .ThenBy(w => w.Title)
          .Include(w => w.Author)
          .Include(w => w.WritingStyle)
          .Include(w => w.WriterRole)
          .IncludeSourceAndPublishers(w => w.Source)
          .IncludeSourceAndPublishers(w => w.Source2)
          .Select(w => w.ToDto())
          .ToListAsync();

      return Ok(works.ToPagedList(page ?? 1, pageSize ?? 25));
    }
  }
}
