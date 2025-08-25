using System;

namespace Server.DTOs;

public class UserOverviewDto
{
  public required string Id { get; set; }
  public required string Username { get; set; }
  public string? ProfilePictureUrl { get; set; }
}
