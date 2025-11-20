using System;
using System.Net;
using AozoraBunkoDatabase.Tests.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;

namespace AozoraBunkoDatabase.Tests.IntegrationTests;

public class WrittenWorksControllerTests
    : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client;
  private readonly CustomWebApplicationFactory<Program> _factory;
  private readonly FactoryDbConnection _connection;

  public WrittenWorksControllerTests(CustomWebApplicationFactory<Program> factory)
  {
    _factory = factory;
    _client = factory.CreateClient(new WebApplicationFactoryClientOptions
    {
      AllowAutoRedirect = false
    });
    _connection = new FactoryDbConnection(_factory);
  }

  [Fact]
  public async Task Get_SuccessfullyRetrieveAllWorks()
  {
    await _connection.UseDbContext(async dbContext =>
    {
      int worksCount = await dbContext.WrittenWorks.CountAsync();
      var response = await _client.GetAsync("/api/writtenWorks");
      var root = await Utils.GetRootElement(response);

      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
      Assert.Equal(worksCount, root.GetArrayLength());
    });
  }

  [Fact]
  public async Task Get_RetrieveBySearch()
  {
    await _connection.UseDbContext(async dbContext =>
    {
      // Osamu Dazai: 人間失格
      var work = await dbContext.WrittenWorks.FindAsync("000301");
      var response = await _client.GetAsync("/api/writtenWorks?s=人間失格");
      var root = await Utils.GetRootElement(response);

      Assert.Contains(work?.Id!, root[0].GetProperty("id").ToString());
      Assert.Contains(work?.Title!, root[0].GetProperty("title").ToString());
    });
  }

  [Fact]
  public async Task Get_RetrieveByAuthorId()
  {
    await _connection.UseDbContext(async dbContext =>
    {
      // Natsume Soseki Id: 000148
      var author = await dbContext.Authors.FindAsync("000148");
      var response = await _client.GetAsync("/api/writtenWorks?authorId=000148");
      var root = await Utils.GetRootElement(response);

      Assert.All(root.EnumerateArray(),
                 work => Assert.Contains(author?.Id!, work.GetProperty("author").GetProperty("id").ToString()));
    });
  }

  [Fact]
  public async Task Get_CanLimitPageSize()
  {
    await _connection.UseDbContext(async dbContext =>
    {
      var response = await _client.GetAsync("/api/writtenWorks?pageSize=3");
      var root = await Utils.GetRootElement(response);

      Assert.Equal(3, root.GetArrayLength());
    });
  }

  [Fact]
  public async Task Get_RetrieveWrittenWorkById()
  {
    await _connection.UseDbContext(async dbContext =>
    {
      // Osamu Dazai: 人間失格
      var work = await dbContext.WrittenWorks.FindAsync("000301");
      var response = await _client.GetAsync("/api/writtenWorks/000301");
      var root = await Utils.GetRootElement(response);

      Assert.Contains(work?.Id!, root.GetProperty("id").ToString());
      Assert.Contains(work?.Title!, root.GetProperty("title").ToString());
    });
  }

  [Fact]
  public async Task Get_ReturnNotFoundIfInvalidId()
  {
    await _connection.UseDbContext(async dbContext =>
    {
      var response = await _client.GetAsync("/api/writtenWorks/1234");
      Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    });
  }
}
