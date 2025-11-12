using System;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace AozoraBunkoDatabase.Tests.Integration;

public class IndexPageTests :
    IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client;
  private readonly CustomWebApplicationFactory<Program> _factory;

  public IndexPageTests(
    CustomWebApplicationFactory<Program> factory)
  {
    _factory = factory;
    _client = factory.CreateClient(new WebApplicationFactoryClientOptions
    {
      AllowAutoRedirect = false
    });
  }

  [Fact]
  public async Task Get_RootReturns200()
  {
    var response = await _client.GetAsync("/");

    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
  }

  [Fact]
  public async Task Get_RootSendsWelcomeMessage()
  {
    string welcomeMessage = "青空文庫へようこそ (Welcome to Aozora Bunko)!";

    var response = await _client.GetAsync("/");
    var responseMessage = await response.Content.ReadAsStringAsync();

    Assert.Contains(welcomeMessage, responseMessage);
  }
}
