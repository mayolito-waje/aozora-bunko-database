using System;
using System.IO.Compression;
using AozoraBunkoDatabase.Tests.Helpers;
using Moq;
using Server.Interfaces;
using Server.Services;

namespace AozoraBunkoDatabase.Tests.UnitTests;

public class SourceDataHandlerTests
{
  [Fact]
  public async Task ShouldProperlyDownloadFromSource()
  {
    var handler = await MockHttpHandler.GetMockHandler();
    var mockAozoraDatabaseService = new Mock<IAozoraDatabaseService>();
    var mockClient = new HttpClient(handler.Object);

    var sourceHandler = new SourceDataHandler(mockClient, mockAozoraDatabaseService.Object);
    var response = await sourceHandler.DownloadFromUri("http://mock-url/zip");

    using var stream = await response.Content.ReadAsStreamAsync();
    using var archive = new ZipArchive(stream, ZipArchiveMode.Read);

    Assert.Single(archive.Entries);
    Assert.Equal("aozora_seed.csv", archive.Entries[0].FullName);
  }
}
