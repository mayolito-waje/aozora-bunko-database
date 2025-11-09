using System;
using System.Text.RegularExpressions;
using Server.DTOs;
using Server.Models;

namespace Server.Extensions;

public static class AuthorExtensions
{
  public static AuthorDto ToDto(this Author author)
  {
    return new AuthorDto()
    {
      Id = author.Id,
      Surname = author.Surname,
      SurnameReading = author.SurnameReading,
      SurnameSort = author.SurnameSort,
      SurnameRomaji = author.SurnameRomaji,
      GivenName = author.GivenName,
      GivenNameReading = author.GivenNameReading,
      GivenNameSort = author.GivenNameSort,
      GivenNameRomaji = author.GivenNameRomaji,
      BirthDate = author.BirthDate,
      DeathDate = author.DeathDate,
      PersonalityRights = author.PersonalityRights,
    };
  }

  public static string ToFullName(this Author author)
  {
    var baseAuthorName = $"{author.Surname}{author.GivenName}";

    var baseString = @"\u30A0-\u30FF\u30FC\u30FB";
    var space = @"\s";
    var punct = @"\p{P}";
    var pattern = @$"^[{baseString}{space}{punct}]+$";
    Match isKatakana = Regex.Match(baseAuthorName, pattern, RegexOptions.IgnoreCase);

    string fullName = isKatakana.Success ? $"{author.GivenName}・{author.Surname}" : baseAuthorName;

    return fullName;
  }
}
