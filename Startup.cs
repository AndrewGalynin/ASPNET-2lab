using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace WebApplication1
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddXmlFile("appsettings.xml")
                .AddIniFile("appsettings.ini");

            IConfiguration configuration = configBuilder.Build();

            services.AddSingleton(configuration);

            services.AddSingleton<IConfigurationAnalyzer, ConfigurationAnalyzer>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "myconfig",
                    pattern: "myconfig",
                    defaults: new { controller = "MyConfig", action = "MyConfig" }
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
