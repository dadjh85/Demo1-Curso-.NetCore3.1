using Demo1.Configuration.MapperConfiguration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;

namespace Demo1.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ServiceInformationMapper _serviceInformationMapper;

        public HomeController(IConfiguration configuration, IOptions<ServiceInformationMapper> serviceInformationMapper)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _serviceInformationMapper = serviceInformationMapper.Value ?? throw new ArgumentNullException(nameof(serviceInformationMapper));
        }

        public IActionResult Index()
        {
            string entorno = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            return Content($"Hola Mundo! - valor de la variable de entorno 'ASPNETCORE_ENVIRONMENT': {entorno}");
        }

        [Route("Configuration")]
        public IActionResult GetConfiguration()
        {
            string valueDemo = _configuration["valueDemo"];
            string valueFileXml = _configuration["applicationNameDemo"];
            return Content($"el valor del fichero personalizado de configuración es: {valueDemo} - valor fichero xml: {valueFileXml}");
        }

        [Route("ConfigurationService")]
        public IActionResult GetConfigurationService()
        {
            return Content($"Service Information: url: {_serviceInformationMapper.Url} port: {_serviceInformationMapper.Port} name: {_serviceInformationMapper.Name}");
        }
    }
}
