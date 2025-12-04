using Hangfire;
using Hangfire.Common;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Server.Contexts;
using Server.Data;
using Server.Interfaces;
using Server.Services;

var allowClient = "_allowClient";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
  .AddNewtonsoftJson(options =>
  {
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
  });

builder.Services.AddDbContext<AppDbContext>(options =>
{
  options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options =>
{
  options.AddPolicy(name: allowClient,
                    policy =>
                    {
                      policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod();
                    });
});

// Need to setup default authentication scheme to download from aozora bunko
builder.Services.AddAuthentication(opt =>
{
  opt.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
  opt.DefaultForbidScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);

builder.Services.AddScoped<IWrittenWorksContext, WrittenWorksContext>();
builder.Services.AddScoped<IAuthorsContext, AuthorsContext>();
builder.Services.AddScoped<IPublishersContext, PublishersContext>();
builder.Services.AddScoped<IAozoraDatabaseService, AozoraDatabaseService>();

builder.Services.AddHttpClient<ISourceDataHandler, SourceDataHandler>(client =>
{
  client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0");
})
    .ConfigurePrimaryHttpMessageHandler(() =>
        new HttpClientHandler
        {
          AllowAutoRedirect = true,
          MaxAutomaticRedirections = 10,
          UseDefaultCredentials = true,
        });

if (builder.Environment.IsDevelopment() || builder.Environment.IsProduction())
{
  builder.Services.AddHangfire(x =>
  x.UsePostgreSqlStorage(opt => opt.UseNpgsqlConnection(builder.Configuration.GetConnectionString("HangfireConnection"))));
  builder.Services.AddHangfireServer();
}

var app = builder.Build();

app.UseCors(allowClient);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
  );

app.UseAuthentication();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
  using (var context = scope.ServiceProvider.GetRequiredService<AppDbContext>())
  {
    if (context.Database.GetPendingMigrations().Any())
    {
      context.Database.Migrate();
    }
  }
}

if (builder.Environment.IsDevelopment() || builder.Environment.IsProduction())
{
  app.UseHangfireDashboard();

  var recurringJobs = app.Services.GetRequiredService<IRecurringJobManager>();

  recurringJobs.AddOrUpdate(
    "update-aozora-database",
    Job.FromExpression<ISourceDataHandler>(s => s.StartDatabaseJob()),
    Cron.Weekly()
  );
}

app.Run();

public partial class Program { }
