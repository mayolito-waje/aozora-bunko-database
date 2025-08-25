using System;
using System.ComponentModel.DataAnnotations;

namespace Server.DTOs;

public class UserRegisterDto
{
  [Required]
  [EmailAddress]
  public string Email { get; set; } = "";

  [Required]
  public string Username { get; set; } = "";

  [Required]
  [MinLength(8)]
  public string Password { get; set; } = "";

  public string? ProfilePictureUrl { get; set; }
}
