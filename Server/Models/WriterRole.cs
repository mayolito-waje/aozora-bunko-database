using System.ComponentModel.DataAnnotations;

namespace Server.Models;

public class WriterRole
{
  [Key]
  public required string Role { get; set; }

  public ICollection<WrittenWork> WrittenWorks { get; set; } = new List<WrittenWork>();
}
