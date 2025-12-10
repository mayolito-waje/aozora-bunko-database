using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;
using X.PagedList.Extensions;

namespace Server.Controllers
{
  public class PublishersController : ControllerProvider
  {
    private readonly IPublishersContext _publishersDb;

    public PublishersController(IPublishersContext publishersDb)
    {
      _publishersDb = publishersDb;
    }

    [EndpointDescription("Retrieve publishers")]
    [HttpGet]
    public async Task<IActionResult> RetrievePublishers(int? page, int? pageSize)
    {
      var publishers = await _publishersDb.GetPublishers();

      return Ok(publishers.ToPagedList(page ?? 1, pageSize ?? 25));
    }

    [EndpointDescription("Retrieve publishers by ID")]
    [HttpGet("{id}")]
    public async Task<IActionResult> RetrievePublisherById(string id, int? sourcePage, int? sourcePageSize)
    {
      var publisher = await _publishersDb.GetPublisherById(id);

      if (publisher == null)
        return NotFound();

      var sources = await _publishersDb.IncludeSources(publisher, sourcePage, sourcePageSize);

      return Ok(sources);
    }
  }
}
