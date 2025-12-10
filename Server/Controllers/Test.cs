using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
  public class Test(IHostEnvironment env) : ControllerProvider
  {
    [EndpointDescription("A testing endpoint that test if hangfire job works correctly. Should be used with caution as it downloads big data on Aozora Bunko")]
    [HttpGet("test-db-populate")]
    public ActionResult<string> PopulateDB()
    {
      if (!env.IsDevelopment())
        return Forbid();

      RecurringJob.TriggerJob("update-aozora-database");

      return "Database population testing completed.";
    }
  }
}
