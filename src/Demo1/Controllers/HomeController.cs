using Microsoft.AspNetCore.Mvc;
using System;

namespace Demo1.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string entorno = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            return Content($"Hola Mundo! - valor de la variable de entorno 'ASPNETCORE_ENVIRONMENT': {entorno}");
        }
    }
}
