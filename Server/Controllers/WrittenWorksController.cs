using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Extensions;
using Server.Models;
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
                              (w.Title.ToLower().Contains(search == null ? "" : search.ToLower()) ||
                              w.TitleReading.ToLower().Contains(search == null ? "" : search.ToLower()) ||
                              w.TitleSort.ToLower().Contains(search == null ? "" : search.ToLower())))
                    .OrderBy(w => w.TitleSort)
                    .ThenBy(w => w.TitleReading)
                    .ThenBy(w => w.Title)
                    .Include(w => w.Author)
                    .Include(w => w.WritingStyle)
                    .Include(w => w.WriterRole)
                    .Include(w => w.Source)
                    .Include(w => w.Source.Publisher)
                    .Include(w => w.Source.OriginalSource)
                    .Include(w => w.Source.OriginalSource.Publisher)
                    .Include(w => w.Source2)
                    .Include(w => w.Source2.Publisher)
                    .Include(w => w.Source2.OriginalSource)
                    .Include(w => w.Source2.OriginalSource.Publisher)
                    .Select(w => w.ToDto())
                    .ToListAsync();

      return Ok(works.ToPagedList(page ?? 1, pageSize ?? 25));
    }
  }
}
