public class Author
{
  public required string Id { get; set; }
  public string? Surname { get; set; }
  public string? SurnameReading { get; set; }
  public string? SurnameSort { get; set; }
  public string? SurnameRomaji { get; set; }
  public string? GivenName { get; set; }
  public string? GivenNameReading { get; set; }
  public string? GivenNameSort { get; set; }
  public string? GivenNameRomaji { get; set; }
  public string? RoleFlag { get; set; }
  public DateOnly? BirthDate { get; set; }
  public DateOnly? DeathDate { get; set; }
  public bool? PersonalityRights { get; set; }
}
