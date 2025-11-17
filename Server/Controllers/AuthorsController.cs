using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;
using X.PagedList.Extensions;

namespace Server.Controllers
{
  public class AuthorsController : ControllerProvider
  {
    private readonly IAuthorsContext _authorsDb;

    public AuthorsController(IAuthorsContext authorsDb)
    {
      _authorsDb = authorsDb;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllAuthors([FromQuery(Name = "s")] string? search, int? page, int? pageSize)
    {
      var allAuthors = await _authorsDb.GetAuthors(search);
      return Ok(allAuthors?.ToPagedList(page ?? 1, pageSize ?? 25));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetAuthorById(string id)
    {
      var author = await _authorsDb.GetAuthorById(id);

      if (author == null)
        return NotFound();

      return Ok(author);
    }
  }
}
