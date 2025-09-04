using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models;

public class WritingStyle
{
  [Key]
  [Column("文字使い種別")]
  public required string Style { get; set; }

  public ICollection<WrittenWork> WrittenWorks { get; set; } = new List<WrittenWork>();
}
