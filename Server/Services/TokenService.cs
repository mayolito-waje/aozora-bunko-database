using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Server.Interfaces;
using Server.Models;

namespace Server.Services;

public class TokenService(IConfiguration configuration) : ITokenService
{
  public string GenerateJwt(User user)
  {
    string jwtKey = configuration["JwtKey"]
      ?? throw new Exception("Jwt key not found in configuration file");
    if (jwtKey.Length < 64)
      throw new Exception("JWT key should have a length of >= 64 characters");
    var jwtSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

    var claims = new List<Claim>()
    {
      new(ClaimTypes.NameIdentifier, user.Id),
      new(ClaimTypes.Email, user.Email),
    };

    var credentials = new SigningCredentials(jwtSecret, SecurityAlgorithms.HmacSha512Signature);

    var descriptor = new SecurityTokenDescriptor()
    {
      Subject = new ClaimsIdentity(claims),
      Expires = DateTime.UtcNow.AddDays(7),
      SigningCredentials = credentials,
    };

    var tokenHandler = new JwtSecurityTokenHandler();
    var token = tokenHandler.CreateToken(descriptor);

    return tokenHandler.WriteToken(token);
  }
}
