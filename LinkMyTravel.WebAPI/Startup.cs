using LinkMyTravel.Data;
using LinkMyTravel.WebAPI.Model;
using LinkMyTravel.WebAPI.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LinkMyTravel.WebAPI
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
            //// Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            //services.AddMvc();

            services.AddDbContext<LinkMyTravelContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("LinkMyTravelConnection")));


            services.AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<LinkMyTravelContext>();

            // Add service and create Policy with options
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });


            // Add framework services.
            services.AddMvc();
            services.AddSingleton<ITodoRepository, TodoRepository>();
            //services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseCors("CorsPolicy");
            app.UseIdentity();
            app.UseMvc();

            
            //app.UseCors(builder =>
            //builder.WithOrigins("http://localhost:50841")
            //.AllowAnyHeader()
            //);
            //var cors = new EnableCorsAttribute("http://localhost:50841", "*", "*");
            //app.EnableCors(cors);
            //app.UseApplicationInsightsRequestTelemetry();
            //app.UseApplicationInsightsExceptionTelemetry();
            // global policy - assign here or on each controller


        }
    }
}
