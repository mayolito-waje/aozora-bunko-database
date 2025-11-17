using Server.DTOs.WrittenWorks;
using Server.Extra.Enums;

namespace Server.Interfaces;

public interface IWrittenWorksContext
{
  Task<List<WrittenWorksDto>> GetByQuery(string? search, string? authorId);
  Task<WrittenWorksDto?> GetById(string id);
  Task<List<WrittenWorksDto>?> GetByWritingStyle(string? search, string? authorId, WritingStyles style);
}
