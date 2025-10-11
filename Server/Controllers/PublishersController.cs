using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.DTOs;
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
    }
}
