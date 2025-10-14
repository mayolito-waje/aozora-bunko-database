namespace Server.Models;

public class Source
{
  public string Id { get; set; } = Guid.NewGuid().ToString();
  public required string Name { get; set; }
  public string? PublisherId { get; set; }
  public Publisher? Publisher { get; set; }
  public string? PublishDateInfo { get; set; }
  public string? OriginalSourceId { get; set; }
  public Source? OriginalSource { get; set; }

  public ICollection<WrittenWork> WrittenWorks { get; set; } = new List<WrittenWork>();
  public ICollection<WrittenWork> WrittenWorks2 { get; set; } = new List<WrittenWork>();
  public ICollection<Source> Sources { get; set; } = new List<Source>();
}
