using System;
using Hangfire;
using Hangfire.PostgreSql;
using Server.Contexts;
using Server.Interfaces;
using Server.Services;

namespace Server.Extensions;

public static class ApplicationInjectableServicesExtensions
{
  public static IServiceCollection AddInjectableServices(this IServiceCollection services)
  {
    services.AddScoped<IWrittenWorksContext, WrittenWorksContext>();
    services.AddScoped<IAuthorsContext, AuthorsContext>();
    services.AddScoped<IPublishersContext, PublishersContext>();
    services.AddScoped<IAozoraDatabaseService, AozoraDatabaseService>();

    services.AddHttpClient<ISourceDataHandler, SourceDataHandler>(client =>
    {
      client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0");
    }).ConfigurePrimaryHttpMessageHandler(() =>
        new HttpClientHandler
        {
          AllowAutoRedirect = true,
          MaxAutomaticRedirections = 10,
          UseDefaultCredentials = true,
        }
      );

    return services;
  }

  public static IServiceCollection AddHangfireService(
    this IServiceCollection services, IWebHostEnvironment environment, IConfiguration configuration)
  {
    if (environment.IsDevelopment() || environment.IsProduction())
    {
      services.AddHangfire(x =>
      x.UsePostgreSqlStorage(opt => opt.UseNpgsqlConnection(configuration.GetConnectionString("HangfireConnection"))));
      services.AddHangfireServer();
    }

    return services;
  }
}
