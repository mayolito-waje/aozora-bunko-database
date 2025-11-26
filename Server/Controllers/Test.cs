using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
  public class Test(IHostEnvironment env) : ControllerProvider
  {
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
