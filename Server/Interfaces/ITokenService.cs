using System;
using Server.Models;

namespace Server.Interfaces;

public interface ITokenService
{
  string GenerateJwt(User user);
}
