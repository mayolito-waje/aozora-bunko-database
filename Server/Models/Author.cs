using System.ComponentModel.DataAnnotations.Schema;

public class Author
{
  public required string Id { get; set; }

  [Column("姓")]
  public string? Surname { get; set; }

  [Column("姓読み")]
  public string? SurnameReading { get; set; }

  [Column("姓読みソート用")]
  public string? SurnameSort { get; set; }

  [Column("姓ローマ字")]
  public string? SurnameRomaji { get; set; }

  [Column("名")]
  public string? GivenName { get; set; }

  [Column("名読み")]
  public string? GivenNameReading { get; set; }

  [Column("名読みソート用")]
  public string? GivenNameSort { get; set; }

  [Column("名ローマ字")]
  public string? GivenNameRomaji { get; set; }

  [Column("生年月日")]
  public DateOnly? BirthDate { get; set; }

  [Column("没年月日")]
  public DateOnly? DeathDate { get; set; }

  [Column("人物著作権フラグ")]
  public bool? PersonalityRights { get; set; }
}
