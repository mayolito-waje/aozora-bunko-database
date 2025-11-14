using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.Interfaces;

namespace Server.Controllers
{
  public class Test(IAozoraDatabaseService aozoraDatabaseService, IHostEnvironment env, AppDbContext dbContext) : ControllerProvider
  {
    [HttpPost("test-db-populate")]
    public async Task<ActionResult<string>> PopulateDB()
    {
      if (!env.IsDevelopment())
        return Forbid();

      await aozoraDatabaseService.PopulateAozoraDatabase("aozora.csv");

      return "Database population testing completed.";
    }
  }
}
