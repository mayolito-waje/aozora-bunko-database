using System.Net;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace AozoraBunkoDatabase.Tests.IntegrationTests;

public class AuthorControllerTests : BaseIntegrationTest
{
  public AuthorControllerTests(FactoryFixture factory) : base(factory) { }

  [Fact]
  public async Task Get_GetAllAuthorsSuccessfully()
  {
    await Connection.UseDbContext(async dbContext =>
    {
      int authorsCount = await dbContext.Authors.CountAsync();
      var response = await Client.GetAsync("/api/authors");

      Assert.Equal(HttpStatusCode.OK, response.StatusCode);

      var content = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
      var root = content.RootElement;

      Assert.Equal(authorsCount, root.GetArrayLength());
    });
  }

  [Fact]
  public async Task Get_FilterByAuthorName()
  {
    await Connection.UseDbContext(async dbContext =>
    {
      var response = await Client.GetAsync("/api/authors?s=太宰治");

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
    await Connection.UseDbContext(async dbContext =>
    {
      var target = await dbContext.Authors.FindAsync("000035");
      var response = await Client.GetAsync("/api/authors/000035");

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
    await Connection.UseDbContext(async dbContext =>
    {
      var response = await Client.GetAsync("/api/authors/1234");

      Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    });
  }
}
