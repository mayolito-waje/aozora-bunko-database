using System.ComponentModel.DataAnnotations;

namespace Server.Models;

public class WritingStyle
{
  [Key]
  public required string Style { get; set; }

  public ICollection<WrittenWork> WrittenWorks { get; set; } = new List<WrittenWork>();
}
