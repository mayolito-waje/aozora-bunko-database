using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models;

public class WriterRole
{
  [Key]
  [Column("役割フラグ")]
  public required string Role { get; set; }

  public ICollection<WrittenWork> WrittenWorks { get; set; } = new List<WrittenWork>();
}
