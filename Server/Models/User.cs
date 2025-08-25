using System;

namespace Server.Models;

public class User
{
  public string Id { get; set; } = Guid.NewGuid().ToString();
  public required string Email { get; set; }
  public required string Username { get; set; }
  public required byte[] PasswordHash { get; set; }
  public required byte[] PasswordSalt { get; set; }
  public string? ProfilePictureUrl { get; set; }
}
