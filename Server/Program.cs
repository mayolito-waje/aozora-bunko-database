using Microsoft.EntityFrameworkCore;
using Server.Contexts;
using Server.Data;
using Server.Interfaces;
using Server.Services;

var allowClient = "_allowClient";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
  .AddNewtonsoftJson(options =>
  {
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
  });

builder.Services.AddDbContext<AppDbContext>(options =>
{
  options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options =>
{
  options.AddPolicy(name: allowClient,
                    policy =>
                    {
                      policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod();
                    });
});

builder.Services.AddScoped<IWrittenWorksContext, WrittenWorksContext>();
builder.Services.AddScoped<IAuthorsContext, AuthorsContext>();
builder.Services.AddScoped<IPublishersContext, PublishersContext>();
builder.Services.AddScoped<IAozoraDatabaseService, AozoraDatabaseService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

app.UseCors(allowClient);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
  );

app.Run();

public partial class Program { }
