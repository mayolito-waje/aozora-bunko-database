using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models;

public class Source
{
  public string Id { get; set; } = Guid.NewGuid().ToString();

  [Column("底本名")]
  public required string Name { get; set; }

  [Column("底本出版社ID")]
  public string? PublisherId { get; set; }
  public Publisher? Publisher { get; set; }

  [Column("底本出版社発行年")]
  public string? PublishDateInfo { get; set; }

  [Column("底本の親元ID")]
  public string? OriginalSourceId { get; set; }
  public Source? OriginalSource { get; set; }

  public ICollection<WrittenWork> WrittenWorks { get; set; } = new List<WrittenWork>();
  public ICollection<WrittenWork> WrittenWorks2 { get; set; } = new List<WrittenWork>();
  public ICollection<Source> Sources { get; set; } = new List<Source>();
}
