using System;
using Hangfire;
using Hangfire.Common;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Interfaces;

namespace Server.Extensions;

public static class ApplicationExtensions
{
  public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
  {
    using (var scope = app.ApplicationServices.CreateScope())
    {
      using (var context = scope.ServiceProvider.GetRequiredService<AppDbContext>())
      {
        if (context.Database.GetPendingMigrations().Any())
        {
          context.Database.Migrate();
        }
      }
    }

    return app;
  }

  public static IApplicationBuilder UseHangfireServices(this IApplicationBuilder app, IHostEnvironment environment)
  {
    if (environment.IsDevelopment() || environment.IsProduction())
    {
      app.UseHangfireDashboard();

      var recurringJobs = app.ApplicationServices.GetRequiredService<IRecurringJobManager>();

      recurringJobs.AddOrUpdate(
        "update-aozora-database",
        Job.FromExpression<ISourceDataHandler>(s => s.StartDatabaseJob()),
        Cron.Weekly()
      );
    }

    return app;
  }
}
