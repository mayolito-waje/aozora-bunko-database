using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;

namespace Server.Controllers
{
  public class AuthorsController(AppDbContext dbContext) : ControllerProvider
  {
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Author>>> GetAllAuthors()
    {
      var allAuthors = await dbContext.Authors.ToListAsync();
      return allAuthors;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Author>> GetAuthorById(string id)
    {
      var author = await dbContext.Authors.FindAsync(id);

      if (author == null)
        return NotFound();

      return author;
    }
  }
}
