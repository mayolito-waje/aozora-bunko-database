using System;
using System.Net;
using Moq;
using Moq.Protected;

namespace AozoraBunkoDatabase.Tests.Helpers;

public static class MockHttpHandler
{
  public async static Task<Mock<HttpMessageHandler>> GetMockHandler()
  {
    var archiveStream = await DbSeed.CreateMockSeederStream();
    byte[] archiveBytes = archiveStream.ToArray();

    var handler = new Mock<HttpMessageHandler>();

    handler.Protected()
        .Setup<Task<HttpResponseMessage>>(
          "SendAsync",
          ItExpr.IsAny<HttpRequestMessage>(),
          ItExpr.IsAny<CancellationToken>()
        )
        .ReturnsAsync(new HttpResponseMessage
        {
          StatusCode = HttpStatusCode.OK,
          Content = new ByteArrayContent(archiveBytes)
        });

    return handler;
  }
}
