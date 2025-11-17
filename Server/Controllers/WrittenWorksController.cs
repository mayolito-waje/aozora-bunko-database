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

    [HttpGet]
    public async Task<IActionResult> RetrieveWorks([FromQuery(Name = "s")] string? search, string? authorId, int? page, int? pageSize)
    {
      var works = await _writtenWorksDb.GetByQuery(search, authorId);

      return Ok(works.ToPagedList(page ?? 1, pageSize ?? 25));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> RetrieveWorkById(string id)
    {
      var work = await _writtenWorksDb.GetById(id);

      if (work == null) return NotFound();

      return Ok(work);
    }

    [HttpGet("shinji_shinkana")]
    public async Task<IActionResult> ShinjiShinkanaList([FromQuery(Name = "s")] string? search, string? authorId, int? page, int? pageSize)
    {
      var works = await _writtenWorksDb.GetByWritingStyle(search, authorId, WritingStyles.ShinJiShinKana);
      return Ok(works?.ToPagedList(page ?? 1, pageSize ?? 25));
    }

    [HttpGet("kyuuji_kyuukana")]
    public async Task<IActionResult> KyuujiKyuukanaList([FromQuery(Name = "s")] string? search, string? authorId, int? page, int? pageSize)
    {
      var works = await _writtenWorksDb.GetByWritingStyle(search, authorId, WritingStyles.KyuuJiKyuuKana);
      return Ok(works?.ToPagedList(page ?? 1, pageSize ?? 25));
    }

    [HttpGet("shinji_kyuukana")]
    public async Task<IActionResult> ShinjiKyuukanaList([FromQuery(Name = "s")] string? search, string? authorId, int? page, int? pageSize)
    {
      var works = await _writtenWorksDb.GetByWritingStyle(search, authorId, WritingStyles.ShinJiKyuuKana);
      return Ok(works?.ToPagedList(page ?? 1, pageSize ?? 25));
    }

    [HttpGet("non_kana")]
    public async Task<IActionResult> NonKanaList([FromQuery(Name = "s")] string? search, string? authorId, int? page, int? pageSize)
    {
      var works = await _writtenWorksDb.GetByWritingStyle(search, authorId, WritingStyles.Other);
      return Ok(works?.ToPagedList(page ?? 1, pageSize ?? 25));
    }
  }
}
