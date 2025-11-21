using System;
using System.IO.Compression;
using Server.Interfaces;

namespace Server.Services;

public class SourceDataHandler : ISourceDataHandler
{
  private readonly HttpClient _httpClient;
  private readonly IAozoraDatabaseService _aozoraDatabaseService;

  public SourceDataHandler(HttpClient httpClient, IAozoraDatabaseService aozoraDatabaseService)
  {
    _httpClient = httpClient;
    _aozoraDatabaseService = aozoraDatabaseService;
  }

  public async Task StartDatabaseJob()
  {
    string aozoraUrl = "https://www.aozora.gr.jp/index_pages/list_person_all_extended_utf8.zip";

    var response = await DownloadFromUri(aozoraUrl);
    await HandleDatabaseUpdate(response);
  }

  public async Task HandleDatabaseUpdate(HttpResponseMessage response)
  {
    using var zipStream = await response.Content.ReadAsStreamAsync();
    using var zipArchive = new ZipArchive(zipStream, ZipArchiveMode.Read);

    await _aozoraDatabaseService.PopulateAozoraDatabase(zipArchive.Entries[0]);
  }

  public async Task<HttpResponseMessage> DownloadFromUri(string uri)
  {
    var response = await _httpClient.GetAsync(uri);
    response.EnsureSuccessStatusCode();

    return response;
  }
}
