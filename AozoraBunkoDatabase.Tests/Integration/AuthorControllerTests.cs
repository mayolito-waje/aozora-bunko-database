using System.Net;
using System.Text.Json;
using AozoraBunkoDatabase.Tests.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;

namespace AozoraBunkoDatabase.Tests.Integration;

public class AuthorControllerTests :
    IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client;
  private readonly CustomWebApplicationFactory<Program> _factory;
  private FactoryDbConnection _connection;

  public AuthorControllerTests(
      CustomWebApplicationFactory<Program> factory)
  {
    _factory = factory;
    _client = factory.CreateClient(new WebApplicationFactoryClientOptions
    {
      AllowAutoRedirect = false
    });
    _connection = new FactoryDbConnection(_factory);
  }

  [Fact]
  public async Task Get_GetAllAuthorsSuccessfully()
  {
    await _connection.UseDbContext(async dbContext =>
    {
      int authorsCount = await dbContext.Authors.CountAsync();
      var response = await _client.GetAsync("/api/authors");

      Assert.Equal(HttpStatusCode.OK, response.StatusCode);

      var content = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
      var root = content.RootElement;

      Assert.Equal(authorsCount, root.GetArrayLength());
    });
  }

  [Fact]
  public async Task Get_FilterByAuthorName()
  {
    await _connection.UseDbContext(async dbContext =>
    {
      var response = await _client.GetAsync("/api/authors?s=太宰治");

      Assert.Equal(HttpStatusCode.OK, response.StatusCode);

      var jsonObj = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
      var root = jsonObj.RootElement;

      Assert.Contains("治", root[0].GetProperty("givenName").ToString());
      Assert.Contains("太宰", root[0].GetProperty("surname").ToString());
    });
  }

  [Fact]
  public async Task Get_ReturnsAuthorWithId()
  {
    await _connection.UseDbContext(async dbContext =>
    {
      var target = await dbContext.Authors.FindAsync("000035");
      var response = await _client.GetAsync("/api/authors/000035");

      Assert.Equal(HttpStatusCode.OK, response.StatusCode);

      var jsonObj = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
      var root = jsonObj.RootElement;

      Assert.Contains(target?.Id!, root.GetProperty("id").ToString());
      Assert.Contains(target?.GivenName!, root.GetProperty("givenName").ToString());
      Assert.Contains(target?.Surname!, root.GetProperty("surname").ToString());
    });
  }

  [Fact]
  public async Task Get_ReturnNotFoundIfIdNotAvailable()
  {
    await _connection.UseDbContext(async dbContext =>
    {
      var response = await _client.GetAsync("/api/authors/1234");

      Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    });
  }
}
