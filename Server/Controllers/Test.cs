using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;

namespace Server.Controllers
{
  public class Test(IAozoraDatabaseService aozoraDatabaseService) : ControllerProvider
  {
    [HttpPost("test-db-populate")]
    public async Task<ActionResult<string>> PopulateDB()
    {
      await aozoraDatabaseService.PopulateAozoraDatabase();

      return "Database population testing completed.";
    }
  }
}
