using Server.Extensions;

var policyName = "_allowClient";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllerService();
builder.Services.AddDatabaseService(builder.Configuration);
builder.Services.AddCorsService(policyName);
builder.Services.AddAuthService();
builder.Services.AddInjectableServices();
builder.Services.AddHangfireService(builder.Environment, builder.Configuration);
builder.Services.AddOpenApi(options =>
{
  options.ShouldInclude = operation => operation.HttpMethod != null;
});

var app = builder.Build();

app.UseCors(policyName);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
  );

app.UseAuthentication();
app.UseAuthorization();

app.ApplyMigrations();
app.UseHangfireServices(builder.Environment);

if (builder.Environment.IsDevelopment())
{
  app.MapOpenApi();

  app.UseSwaggerUI(options =>
  {
    options.SwaggerEndpoint("/openapi/v1.json", "v1");
  });
}

app.Run();

public partial class Program { }
