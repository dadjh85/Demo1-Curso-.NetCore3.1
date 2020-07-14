using Demo1.Configuration.MapperConfiguration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.TestService;

namespace Demo1
{
    public class Startup
    {
        /// <summary>
        /// Constructor of startup
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Object of load the personal configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// dependency injection container of .NET Core
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.Configure<ServiceInformationMapper>(Configuration.GetSection("ServiceInformation"));

            //Example of IoC in .NET Core
            services.AddScoped<ITestService, TestService>();

            //Example of Get value of ServiceInformationMapper in ConfigureService
            ServiceInformationMapper serviceInformation = new ServiceInformationMapper();
            Configuration.GetSection("ServiceInformation").Bind(serviceInformation);
        }

        /// <summary>
        /// Exclusive pipeline of the environment Development
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureStagingServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddControllers();
        }

        /// <summary>
        /// Pipeline of startup api-rest
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
