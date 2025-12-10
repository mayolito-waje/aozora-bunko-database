using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Server.Data;

namespace Server.Extensions;

public static class ApplicationGeneralServicesExtensions
{
  public static IServiceCollection AddControllerService(this IServiceCollection services)
  {
    services
      .AddControllers()
      .AddNewtonsoftJson(options =>
      {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
      });

    return services;
  }

  public static IServiceCollection AddDatabaseService(this IServiceCollection services, IConfiguration configuration)
  {
    services
      .AddDbContext<AppDbContext>(options =>
        {
          options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

    return services;
  }

  public static IServiceCollection AddCorsService(this IServiceCollection services, string policyName)
  {
    services
      .AddCors(options =>
        {
          options
            .AddPolicy(name: policyName,
              policy =>
              {
                policy.WithOrigins("http://localhost:5173")
                      .AllowAnyHeader()
                      .AllowAnyMethod();
              }
            );
        });

    return services;
  }

  public static IServiceCollection AddAuthService(this IServiceCollection services)
  {
    // Need to setup default authentication scheme to download from aozora bunko
    services.AddAuthentication(opt =>
      {
        opt.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        opt.DefaultForbidScheme = CookieAuthenticationDefaults.AuthenticationScheme;
      }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);

    return services;
  }
}
