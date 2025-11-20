using System;
using Server.Interfaces;

namespace Server.Services;

public class SourceDataHandler : ISourceDataHandler
{
  private readonly HttpClient _httpClient;

  public SourceDataHandler(HttpClient httpClient)
  {
    _httpClient = httpClient;
  }

  public async Task<HttpResponseMessage> DownloadFromUri(string uri)
  {
    var response = await _httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
    response.EnsureSuccessStatusCode();

    return response;
  }
}
