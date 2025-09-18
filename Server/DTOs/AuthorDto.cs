using System;
using Newtonsoft.Json;

namespace Server.DTOs;

public class AuthorDto
{
  public required string Id { get; set; }

  [JsonProperty("姓")]
  public required string Surname { get; set; }

  [JsonProperty("姓読み")]
  public required string SurnameReading { get; set; }

  [JsonProperty("姓読みソート用")]
  public required string SurnameSort { get; set; }

  [JsonProperty("姓ローマ字")]
  public required string SurnameRomaji { get; set; }

  [JsonProperty("名")]
  public string? GivenName { get; set; }

  [JsonProperty("名読み")]
  public string? GivenNameReading { get; set; }

  [JsonProperty("名読みソート用")]
  public string? GivenNameSort { get; set; }

  [JsonProperty("名ローマ字")]
  public string? GivenNameRomaji { get; set; }

  [JsonProperty("生年月日")]
  public DateOnly? BirthDate { get; set; }

  [JsonProperty("没年月日")]
  public DateOnly? DeathDate { get; set; }

  [JsonProperty("人物著作権フラグ")]
  public bool PersonalityRights { get; set; } = false;
}
