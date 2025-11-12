namespace Server.Models;

public class Author
{
  public required string Id { get; set; }
  public required string Surname { get; set; }
  public required string SurnameReading { get; set; }
  public required string SurnameSort { get; set; }
  public required string SurnameRomaji { get; set; }
  public string? GivenName { get; set; }
  public string? GivenNameReading { get; set; }
  public string? GivenNameSort { get; set; }
  public string? GivenNameRomaji { get; set; }
  public string? BirthDate { get; set; }
  public string? DeathDate { get; set; }
  public bool PersonalityRights { get; set; } = false;

  public ICollection<WrittenWork> WrittenWorks { get; set; } = new List<WrittenWork>();
}
