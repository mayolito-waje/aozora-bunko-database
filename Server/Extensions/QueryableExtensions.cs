using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Extensions;

public static class QueryableExtensions
{
  public static IQueryable<WrittenWork> IncludeSourceAndPublishers(
    this IQueryable<WrittenWork> query,
    Expression<Func<WrittenWork, Source?>> sourceSelector)
  {
    return query
          .Include(sourceSelector)
            .ThenInclude(s => s!.Publisher)
          .Include(sourceSelector)
            .ThenInclude(s => s!.OriginalSource)
              .ThenInclude(os => os!.Publisher);
  }

  public static IQueryable<WrittenWork> SortAndIncludeDetails(this IQueryable<WrittenWork> query)
  {
    return query
          .OrderBy(w => w.TitleSort)
          .ThenBy(w => w.TitleReading)
          .ThenBy(w => w.Title)
          .Include(w => w.Author)
          .Include(w => w.WritingStyle)
          .Include(w => w.WriterRole)
          .IncludeSourceAndPublishers(w => w.Source)
          .IncludeSourceAndPublishers(w => w.Source2);
  }

  public static IQueryable<WrittenWork> IsMatchingSearchAndAuthor(
    this IQueryable<WrittenWork> query, string? search, string? authorId)
  {
    return query
           .Where(w =>
             (authorId == null || w.AuthorId == authorId) &&
             (string.IsNullOrEmpty(search) ||
              EF.Functions.Like(w.Title, $"%{search}%") ||
              EF.Functions.Like(w.TitleReading, $"%{search}%") ||
              EF.Functions.Like(w.TitleSort, $"%{search}%")));
  }
}
