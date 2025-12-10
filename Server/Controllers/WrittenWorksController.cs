using Microsoft.AspNetCore.Mvc;
using Server.Extra.Enums;
using Server.Interfaces;
using X.PagedList.Extensions;

namespace Server.Controllers
{
  public class WrittenWorksController : ControllerProvider
  {
    private readonly IWrittenWorksContext _writtenWorksDb;

    public WrittenWorksController(IWrittenWorksContext writtenWorksDb)
    {
      _writtenWorksDb = writtenWorksDb;
    }

    [EndpointDescription("Retrieve written works that allow filtering by search query (s) and author ID (authorId)")]
    [HttpGet]
    public async Task<IActionResult> RetrieveWorks([FromQuery(Name = "s")] string? search, string? authorId, int? page, int? pageSize)
    {
      var works = await _writtenWorksDb.GetByQuery(search, authorId);

      return Ok(works.ToPagedList(page ?? 1, pageSize ?? 25));
    }

    [EndpointDescription("Retrieve written work by their corresponding ID")]
    [HttpGet("{id}")]
    public async Task<IActionResult> RetrieveWorkById(string id)
    {
      var work = await _writtenWorksDb.GetById(id);

      if (work == null) return NotFound();

      return Ok(work);
    }

    [EndpointDescription("Retrieve written works that is formatted in 新字新仮名 format")]
    [HttpGet("shinji_shinkana")]
    public async Task<IActionResult> ShinjiShinkanaList([FromQuery(Name = "s")] string? search, string? authorId, int? page, int? pageSize)
    {
      var works = await _writtenWorksDb.GetByWritingStyle(search, authorId, WritingStyles.ShinJiShinKana);
      return Ok(works?.ToPagedList(page ?? 1, pageSize ?? 25));
    }

    [EndpointDescription("Retrieve written works that is formatted in 旧字旧仮名 format")]
    [HttpGet("kyuuji_kyuukana")]
    public async Task<IActionResult> KyuujiKyuukanaList([FromQuery(Name = "s")] string? search, string? authorId, int? page, int? pageSize)
    {
      var works = await _writtenWorksDb.GetByWritingStyle(search, authorId, WritingStyles.KyuuJiKyuuKana);
      return Ok(works?.ToPagedList(page ?? 1, pageSize ?? 25));
    }

    [EndpointDescription("Retrieve written works that is formatted in 新字旧仮名 format")]
    [HttpGet("shinji_kyuukana")]
    public async Task<IActionResult> ShinjiKyuukanaList([FromQuery(Name = "s")] string? search, string? authorId, int? page, int? pageSize)
    {
      var works = await _writtenWorksDb.GetByWritingStyle(search, authorId, WritingStyles.ShinJiKyuuKana);
      return Ok(works?.ToPagedList(page ?? 1, pageSize ?? 25));
    }

    [EndpointDescription("Retrieve written works that is formatted in non-kana format (e.g. Latin alphabet)")]
    [HttpGet("non_kana")]
    public async Task<IActionResult> NonKanaList([FromQuery(Name = "s")] string? search, string? authorId, int? page, int? pageSize)
    {
      var works = await _writtenWorksDb.GetByWritingStyle(search, authorId, WritingStyles.Other);
      return Ok(works?.ToPagedList(page ?? 1, pageSize ?? 25));
    }
  }
}
