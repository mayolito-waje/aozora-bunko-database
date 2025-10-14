namespace Server.Models;

public class Publisher
{
  public string Id { get; set; } = Guid.NewGuid().ToString();
  public required string Name { get; set; }

  public ICollection<Source> Sources { get; set; } = new List<Source>();
}
