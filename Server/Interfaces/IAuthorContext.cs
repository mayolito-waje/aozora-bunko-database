using System;
using Server.DTOs;

namespace Server.Interfaces;

public interface IAuthorsContext
{
  Task<List<AuthorDto>?> GetAuthors(string? search);
  Task<AuthorDto?> GetAuthorById(string id);
}
