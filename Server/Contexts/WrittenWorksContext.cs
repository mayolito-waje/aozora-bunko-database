using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.DTOs.WrittenWorks;
using Server.Extensions;
using Server.Extra.Enums;
using Server.Interfaces;

namespace Server.Contexts;

public class WrittenWorksContext : IWrittenWorksContext
{

  private readonly AppDbContext _dbContext;

  public WrittenWorksContext(AppDbContext dbContext)
  {
    _dbContext = dbContext;
  }
  public async Task<List<WrittenWorksDto>> GetByQuery(string? search, string? authorId)
  {
    var works = await _dbContext.WrittenWorks
      .IsMatchingSearchAndAuthor(search, authorId)
      .SortAndIncludeDetails()
      .Select(w => w.ToDto())
      .ToListAsync();

    return works;
  }

  public async Task<WrittenWorksDto?> GetById(string id)
  {
    var work = await _dbContext.WrittenWorks
      .Include(w => w.Author)
      .Include(w => w.WritingStyle)
      .Include(w => w.WriterRole)
      .IncludeSourceAndPublishers(w => w.Source)
      .IncludeSourceAndPublishers(w => w.Source2)
      .FirstOrDefaultAsync(w => w.Id == id);

    return work?.ToDto();
  }

  public async Task<List<WrittenWorksDto>?> GetByWritingStyle(string? search, string? authorId, WritingStyles style)
  {
    string writingStyle = "";

    switch (style)
    {
      case WritingStyles.ShinJiShinKana:
        writingStyle = "新字新仮名";
        break;
      case WritingStyles.KyuuJiKyuuKana:
        writingStyle = "旧字旧仮名";
        break;
      case WritingStyles.ShinJiKyuuKana:
        writingStyle = "新字旧仮名";
        break;
      default:
        writingStyle = "その他";
        break;
    }

    var works = await _dbContext.WrittenWorks
      .IsMatchingSearchAndAuthor(search, authorId)
      .Where(w => w.WritingStyle!.Style == writingStyle)
      .SortAndIncludeDetails()
      .Select(w => w.ToDto())
      .ToListAsync();

    return works;
  }
}
