using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TinyAchievements.DataAccess;
using TinyAchievements.Commons.DataAccess;
using Dapper.Contrib.Extensions;
using Microsoft.OpenApi.Models;

namespace TinyAchievements
{
    /// <summary>
    /// The Startup class is where services required by the app are configured and request handling pipeline is defined.
    /// </summary>
    /// <remarks>
    /// The Startup class is specified when the app's host is built. The Startup class is typically 
    /// specified by calling the WebHostBuilderExtensions.UseStartup<TStartup> method on the host builder
    /// details: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/?view=aspnetcore-3.1&tabs=windows
    /// </remarks>
    internal class Startup
    {
        /// <summary>
        /// The host provides services that are available to the Startup class constructor. 
        /// </summary>
        /// <remarks>
        /// The app adds additional services via ConfigureServices (optional).
        /// The host may configure some services before Startup methods are called.
        /// Both the host and app services are available in Configure and throughout the app.
        /// </remarks>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        internal IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the .NET Core runtime. Use this method to add services to the services container.
        /// </summary>
        /// <remarks>
        /// Optional
        /// A service is a reusable component that are used by the app and provide specific app functionality.
        /// E.g. a logging component is a service
        /// Services are registered in ConfigureServices and consumed across the app 
        /// via dependency injection (DI) or ApplicationServices.
        /// Code to configure (or register) services should be added here.
        /// Called by the webhost before the Configure method to configure the app's services.
        /// details: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/startup?view=aspnetcore-3.1
        /// </remarks>
        public void ConfigureServices(IServiceCollection services)
        {
            // this lifetime service is created when this service is deployed since an instance is specified 
            // with the service registration.
            
            services.AddSingleton(new MySqlConnectionHelper(Configuration["ConnectionStrings:MySql"]));

            // this lifetime service is created once per client request (connection).
            // differences see: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.1#service-lifetimes-and-registration-options
            services.AddScoped<IAchievementRepository, AchievementRepository>();

            // default
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // A Swagger generator that builds SwaggerDocument objects directly from routs, controllers,
            // and models. Combine this with swagger endpoint middleware to automatically expose
            // Swagger JSON
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "TinyAchievements API", Version = "v1" });
            });
        }

        /// <summary>
        /// This method gets called by the ASP.NET Core runtime. Use this method to configure the HTTP request 
        /// processing pipeline.
        /// </summary>
        /// <remarks>
        /// The request handling pipeline is composed as a series of 'middleware' components.
        /// E.g. middleware might handle requests for static files or redirect HTTP to HTTPS requests.
        /// Each middleware performs an asynchronous operations on an HttpContext and then either invokes 
        /// the next middleware
        /// or terminates the request.
        /// The request pipeline is configured by adding middleware components to an IApplicationBuilder instance.
        /// Additional services, such as IWebHostEnvironment, ILoggerFactory, or anything defined in ConfigureServices, 
        /// can be specified in the Configure method signature. These services are injected if they're available.
        /// Middleware is software that's assembled into an app pipeline to handle requests and responses.
        /// each middleware component chooses whether to pass the request to the next component in the pipeline.
        /// each can perform work before and after the next component in the pipeline.
        ///
        /// Request delegates are used to build the request pipeline. The request delegates handle each HTTP request.
        /// Request delegates are configured using Run, Map, and Use extension methods.
        /// Run extension are always ternimal and terminates the pipeline.
        /// Map extension are used as a convention for branching the pipeline
        /// Use extension chains multiple requests delegates together.
        /// 
        /// An individual request delegate can be specified in-line as an anonymous method (called in-line middleware), or
        /// it can be defined in a reusable class. These reusable classes and in-line anonymous methods are middleware,
        /// also called middleware components.
        /// Each middleware component in the request pipeline is responsible for invoking the next component in the pipeline
        /// or short-circuiting the pipeline. When a middleware short-circuits, it's called a terminal middleware
        /// because it prevents further middleware from processing the request.
        /// details: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-3.1
        /// </remarks>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.r it from.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TinyAchievements API");
            });

            // Allows us to apply a custom mapping using type names as the table names
            SqlMapperExtensions.TableNameMapper = type => type.Name;
        }
    }
}
