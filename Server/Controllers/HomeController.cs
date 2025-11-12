using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
  public class HomeController : ControllerProvider
  {
    [Route("/")]
    [Route("home")]
    [Route("home/index")]
    public IActionResult Index()
    {
      return Ok("青空文庫へようこそ (Welcome to Aozora Bunko)!");
    }
  }
}
