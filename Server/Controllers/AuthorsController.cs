using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Extensions;
using X.PagedList.Extensions;

namespace Server.Controllers
{
  public class AuthorsController(AppDbContext dbContext) : ControllerProvider
  {
    [HttpGet]
    public async Task<ActionResult> GetAllAuthors([FromQuery(Name = "s")] string? search, int? page, int? pageSize)
    {
      var allAuthors = await dbContext.Authors
        .Where(a => EF.Functions.Like(a.Surname + a.GivenName, $"%{search}%") ||
                    EF.Functions.Like(a.GivenName + a.Surname, $"%{search}%") ||
                    EF.Functions.Like(a.GivenNameReading + a.SurnameReading, $"%{search}%") ||
                    EF.Functions.Like((a.GivenNameRomaji != null ? a.GivenNameRomaji.ToLower() : "")
                                        + " " + a.SurnameRomaji.ToLower(), $"%{search}%"))
        .Select(a => a.ToDto())
        .ToListAsync();

      return Ok(allAuthors.ToPagedList(page ?? 1, pageSize ?? 25));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetAuthorById(string id)
    {
      var author = await dbContext.Authors.FindAsync(id);

      if (author == null)
        return NotFound();

      return Ok(author.ToDto());
    }
  }
}
