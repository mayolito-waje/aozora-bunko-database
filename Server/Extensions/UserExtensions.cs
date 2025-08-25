using System;
using Server.DTOs;
using Server.Interfaces;
using Server.Models;

namespace Server.Extensions;

public static class UserExtensions
{
  public static UserDto GenerateToken(this User user, ITokenService tokenService)
  {
    return new UserDto()
    {
      Id = user.Id,
      Email = user.Email,
      Username = user.Username,
      ProfilePictureUrl = user.ProfilePictureUrl,
      Token = tokenService.GenerateJwt(user),
    };
  }

  public static UserOverviewDto Overview(this User user)
  {
    return new UserOverviewDto()
    {
      Id = user.Id,
      Username = user.Username,
      ProfilePictureUrl = user.ProfilePictureUrl,
    };
  }
}
