using System;

namespace Server.Interfaces;

public interface ISourceDataHandler
{
  Task<HttpResponseMessage> DownloadFromUri(string uri);
  Task HandleDatabaseUpdate(HttpResponseMessage response);
  Task StartDatabaseJob();
}
