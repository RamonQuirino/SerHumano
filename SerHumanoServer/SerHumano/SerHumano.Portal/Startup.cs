using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using MySQL.Data.EntityFrameworkCore;
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
using SerHumano.Repository.Person;
using SerHumano.Repository.Security;

namespace SerHumano.Portal
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkMySQL()
                .AddDbContext<SerHumanoContext>(options =>
                    options.UseMySQL(Configuration.GetConnectionString("SerHumanoConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<SerHumanoContext>()
                .AddDefaultTokenProviders();

            ConfigureInjectionContext(services);
            
            services.AddMvc();
        }

        private static void ConfigureInjectionContext(IServiceCollection services)
        {
            services.Replace(ServiceDescriptor.Transient(typeof(IUserRepository), typeof(UserRepository)));
            services.Replace(ServiceDescriptor.Transient(typeof(IPersonRepository), typeof(PersonRepository)));

            services.Replace(ServiceDescriptor.Transient(typeof(IUserService), typeof(UserService)));
            services.Replace(ServiceDescriptor.Transient(typeof(IPersonService), typeof(PersonService)));

            services.Replace(ServiceDescriptor.Transient(typeof(IAuthenticationApplication),
                typeof(AuthenticationApplication)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {            
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
    public class ApplicationUser : IdentityUser
    {
    }
}
