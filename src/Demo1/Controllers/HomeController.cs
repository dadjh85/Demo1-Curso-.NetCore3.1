using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Hello world!");
        }
    }
}
