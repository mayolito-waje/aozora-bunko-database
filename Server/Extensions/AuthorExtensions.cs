using System;
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
}
