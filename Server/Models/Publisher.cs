using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models;

public class Publisher
{
  public string Id { get; set; } = Guid.NewGuid().ToString();

  [Column("出版社名")]
  public required string Name { get; set; }

  public ICollection<Source> Sources { get; set; } = new List<Source>();
}
