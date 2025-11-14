using System;
using System.Text.Json;

namespace AozoraBunkoDatabase.Tests.Helpers;

public static class Utils
{
  public static async Task<JsonElement> GetRootElement(HttpResponseMessage serverResponse)
  {
    var jsonDocument = JsonDocument.Parse(await serverResponse.Content.ReadAsStreamAsync());
    var root = jsonDocument.RootElement;

    return root;
  }
}
