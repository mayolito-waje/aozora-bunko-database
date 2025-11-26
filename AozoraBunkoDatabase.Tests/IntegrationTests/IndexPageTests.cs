using System.Net;

namespace AozoraBunkoDatabase.Tests.IntegrationTests;

public class IndexPageTests : BaseIntegrationTest
{
  public IndexPageTests(FactoryFixture factory) : base(factory) { }

  [Fact]
  public async Task Get_RootReturns200()
  {
    var response = await Client.GetAsync("/");

    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
  }

  [Fact]
  public async Task Get_RootSendsWelcomeMessage()
  {
    string welcomeMessage = "青空文庫へようこそ (Welcome to Aozora Bunko)!";

    var response = await Client.GetAsync("/");
    var responseMessage = await response.Content.ReadAsStringAsync();

    Assert.Contains(welcomeMessage, responseMessage);
  }
}
