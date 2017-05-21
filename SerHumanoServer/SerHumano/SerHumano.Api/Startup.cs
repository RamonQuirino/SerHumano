using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MySQL.Data.EntityFrameworkCore.Extensions;
using SerHumano.Application.Authentication;
using SerHumano.Common.Applications.Authentication;
using SerHumano.Common.Services.Person;
using SerHumano.Common.Services.Security;
using SerHumano.Domain.Repositories.Person;
using SerHumano.Domain.Repositories.Security;
using SerHumano.Domain.Services.Person;
using SerHumano.Domain.Services.Security;
using SerHumano.Repository;
using SerHumano.Repository.Data;
using SerHumano.Repository.Person;
using SerHumano.Repository.Security;

namespace SerHumano.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<SerHumanoContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("SerHumanoConnection")));

            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();

            //Aplication Injection
            services.AddTransient<IAuthenticationApplication, AuthenticationApplication>();

            //Services Injection
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IUserService, UserService>();

            //Repository injection
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, SerHumanoContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseMvc();


            DbInitializer.Initialize(context);
        }
    }
}
