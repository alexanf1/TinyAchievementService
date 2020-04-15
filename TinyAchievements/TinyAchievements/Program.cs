using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace TinyAchievements
{
    /// <summary>
    /// This is where all the magic happens...
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main entry point into the application. Creates a host.
        /// </summary>
        /// <remarks>
        /// ASP.NET Core apps configure and launch a 'host'
        /// The host is responsible for app startup and lifetime management
        /// The host configures a server, a request processing pipeline, and additional setups
        /// such as logging, DI, and various configurations
        /// </remarks>
        public static void Main(string[] args)
        {
            /* CreateDefaultBuilder performs the following tasks:
             * Configures Kestrel server as the web server using the app's hosting configuration providers. For the Kestrel server's default options, see Kestrel web server implementation in ASP.NET Core.
             * Sets the content root to the path returned by Directory.GetCurrentDirectory.
             * Loads host configuration from:
                * Command-line arguments.
             * Loads app configuration in the following order from:
                * appsettings.json.
                * appsettings.{Environment}.json.
                * Secret Manager when the app runs in the Development environment using the entry assembly.
                * Environment variables.
                * Command-line arguments.
             * Configures logging for console and debug output. Logging includes log filtering rules specified in a Logging configuration section of an appsettings.json or appsettings.{Environment}.json file.
             * When running behind IIS with the ASP.NET Core Module, CreateDefaultBuilder enables IIS Integration, which configures the app's base address and port. IIS Integration also configures the app to capture startup errors. For the IIS default options, see Host ASP.NET Core on Windows with IIS.
             * Sets ServiceProviderOptions.ValidateScopes to true if the app's environment is Development. For more information, see Scope validation.
             * Any configurations defined by CreateDefaultBuilder can be overriden and augmented by ConfigureAppConfiguration
             */
            IWebHostBuilder host = WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
            host.Build().Run();
        }
    }
}
