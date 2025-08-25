using System;

namespace Server.DTOs;

public class UserDto
{
  public required string Id { get; set; }
  public required string Email { get; set; }
  public required string Username { get; set; }
  public string? ProfilePictureUrl { get; set; }
  public required string Token { get; set; }
}
