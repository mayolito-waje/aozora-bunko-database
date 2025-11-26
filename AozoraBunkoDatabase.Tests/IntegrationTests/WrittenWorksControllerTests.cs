using System.Net;
using AozoraBunkoDatabase.Tests.Helpers;
using Microsoft.EntityFrameworkCore;

namespace AozoraBunkoDatabase.Tests.IntegrationTests;

public class WrittenWorksControllerTests : BaseIntegrationTest
{
  public WrittenWorksControllerTests(FactoryFixture factory) : base(factory) { }

  [Fact]
  public async Task Get_SuccessfullyRetrieveAllWorks()
  {
    await Connection.UseDbContext(async dbContext =>
    {
      int worksCount = await dbContext.WrittenWorks.CountAsync();
      var response = await Client.GetAsync("/api/writtenWorks");
      var root = await Utils.GetRootElement(response);

      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
      Assert.Equal(worksCount, root.GetArrayLength());
    });
  }

  [Fact]
  public async Task Get_RetrieveBySearch()
  {
    await Connection.UseDbContext(async dbContext =>
    {
      // Osamu Dazai: 人間失格
      var work = await dbContext.WrittenWorks.FindAsync("000301");
      var response = await Client.GetAsync("/api/writtenWorks?s=人間失格");
      var root = await Utils.GetRootElement(response);

      Assert.Contains(work?.Id!, root[0].GetProperty("id").ToString());
      Assert.Contains(work?.Title!, root[0].GetProperty("title").ToString());
    });
  }

  [Fact]
  public async Task Get_RetrieveByAuthorId()
  {
    await Connection.UseDbContext(async dbContext =>
    {
      // Natsume Soseki Id: 000148
      var author = await dbContext.Authors.FindAsync("000148");
      var response = await Client.GetAsync("/api/writtenWorks?authorId=000148");
      var root = await Utils.GetRootElement(response);

      Assert.All(root.EnumerateArray(),
                 work => Assert.Contains(author?.Id!, work.GetProperty("author").GetProperty("id").ToString()));
    });
  }

  [Fact]
  public async Task Get_CanLimitPageSize()
  {
    await Connection.UseDbContext(async dbContext =>
    {
      var response = await Client.GetAsync("/api/writtenWorks?pageSize=3");
      var root = await Utils.GetRootElement(response);

      Assert.Equal(3, root.GetArrayLength());
    });
  }

  [Fact]
  public async Task Get_RetrieveWrittenWorkById()
  {
    await Connection.UseDbContext(async dbContext =>
    {
      // Osamu Dazai: 人間失格
      var work = await dbContext.WrittenWorks.FindAsync("000301");
      var response = await Client.GetAsync("/api/writtenWorks/000301");
      var root = await Utils.GetRootElement(response);

      Assert.Contains(work?.Id!, root.GetProperty("id").ToString());
      Assert.Contains(work?.Title!, root.GetProperty("title").ToString());
    });
  }

  [Fact]
  public async Task Get_ReturnNotFoundIfInvalidId()
  {
    await Connection.UseDbContext(async dbContext =>
    {
      var response = await Client.GetAsync("/api/writtenWorks/1234");
      Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    });
  }
}
