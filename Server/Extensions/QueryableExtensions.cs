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
}
