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
          .IsMatchingSearchAndAuthor(search, authorId)
          .SortAndIncludeDetails()
          .Select(w => w.ToDto())
          .ToListAsync();

      return Ok(works.ToPagedList(page ?? 1, pageSize ?? 25));
    }

    [HttpGet("shinji_shinkana")]
    public async Task<IActionResult> ShinjiShinkanaList([FromQuery(Name = "s")] string? search, string? authorId, int? page, int? pageSize)
    {
      var works = await dbContext.WrittenWorks
          .IsMatchingSearchAndAuthor(search, authorId)
          .Where(w => w.WritingStyle!.Style == "新字新仮名")
          .SortAndIncludeDetails()
          .Select(w => w.ToDto())
          .ToListAsync();

      return Ok(works.ToPagedList(page ?? 1, pageSize ?? 25));
    }

    [HttpGet("kyuuji_kyuukana")]
    public async Task<IActionResult> KyuujiKyuukanaList([FromQuery(Name = "s")] string? search, string? authorId, int? page, int? pageSize)
    {
      var works = await dbContext.WrittenWorks
          .IsMatchingSearchAndAuthor(search, authorId)
          .Where(w => w.WritingStyle!.Style == "旧字旧仮名")
          .SortAndIncludeDetails()
          .Select(w => w.ToDto())
          .ToListAsync();

      return Ok(works.ToPagedList(page ?? 1, pageSize ?? 25));
    }

    [HttpGet("shinji_kyuukana")]
    public async Task<IActionResult> ShinjiKyuukanaList([FromQuery(Name = "s")] string? search, string? authorId, int? page, int? pageSize)
    {
      var works = await dbContext.WrittenWorks
          .IsMatchingSearchAndAuthor(search, authorId)
          .Where(w => w.WritingStyle!.Style == "新字旧仮名")
          .SortAndIncludeDetails()
          .Select(w => w.ToDto())
          .ToListAsync();

      return Ok(works.ToPagedList(page ?? 1, pageSize ?? 25));
    }

    [HttpGet("non_kana")]
    public async Task<IActionResult> NonKanaList([FromQuery(Name = "s")] string? search, string? authorId, int? page, int? pageSize)
    {
      var works = await dbContext.WrittenWorks
          .IsMatchingSearchAndAuthor(search, authorId)
          .Where(w => w.WritingStyle!.Style == "その他")
          .SortAndIncludeDetails()
          .Select(w => w.ToDto())
          .ToListAsync();

      return Ok(works.ToPagedList(page ?? 1, pageSize ?? 25));
    }
  }
}
