using System;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.DTOs;
using Server.Extensions;
using Server.Interfaces;

namespace Server.Contexts;

public class AuthorsContext : IAuthorsContext
{
  private readonly AppDbContext _dbContext;

  public AuthorsContext(AppDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<List<AuthorDto>?> GetAuthors(string? search)
  {
    var allAuthors = await _dbContext.Authors
      .Where(a => EF.Functions.Like(a.Surname + a.GivenName, $"%{search}%") ||
                  EF.Functions.Like(a.GivenName + a.Surname, $"%{search}%") ||
                  EF.Functions.Like(a.GivenNameReading + a.SurnameReading, $"%{search}%") ||
                  EF.Functions.Like((a.GivenNameRomaji != null ? a.GivenNameRomaji.ToLower() : "")
                                      + " " + a.SurnameRomaji.ToLower(), $"%{search}%"))
      .Select(a => a.ToDto())
      .ToListAsync();

    return allAuthors;
  }

  public async Task<AuthorDto?> GetAuthorById(string id)
  {
    var author = await _dbContext.Authors.FindAsync(id);
    return author?.ToDto();
  }
}
