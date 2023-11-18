using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Bakery_Oven
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IServiceCollection services = new ServiceCollection();

            ApplicationConfiguration.Initialize();

            ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            Application.Run(new Form1());
        }

        static void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<OnOffService>();
            services.AddSingleton<TemperatureService>();
        }
    }
}