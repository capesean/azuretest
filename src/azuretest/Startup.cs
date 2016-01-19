using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IXESHA
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public static void Main(string[] args)
        {
            var hostingConfiguration = WebHostConfiguration.GetDefault(args);
            var application = new WebHostBuilder()
                .UseConfiguration(hostingConfiguration)
                .UseIISPlatformHandlerUrl()
                .UseStartup<Startup>()
                .Build();

            application.Run();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseIISPlatformHandler();

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "DefaultApi",
                    template: "api/{controller}");
            });

        }
    }
}
