using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Reflection;

namespace Demo1
{
    /// <summary>
    /// Class principal for startup api-rest
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((builder, config) =>
                {
                    string envirnmentName = builder.HostingEnvironment.EnvironmentName;
                    string publishPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                    config.SetBasePath(publishPath)
                          .AddXmlFile("Configuration/ConfigurationDemo.xml")
                          .AddJsonFile("Configuration/ConfigurationDemo.json")
                          .AddJsonFile($"Configuration/ConfigurationDemo.{envirnmentName}.json");
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
