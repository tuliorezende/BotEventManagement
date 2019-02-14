using System;
using System.IO;
using BotEventManagement.Services.Interfaces;
using BotEventManagement.Services.Model.Database;
using BotEventManagement.Services.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using BotEventManagement.Api.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Linq;
using Newtonsoft.Json;

namespace BotEventTemplate.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment environment)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables().Build();

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine("Configure Services - Begin");
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            Console.WriteLine("Configure Services - Before Database Configuration");
            services.AddDbContext<BotEventManagementContext>(options => options.UseSqlServer(Configuration["DefaultConnection"]));

            Console.WriteLine("Configure Services - Before Swagger Configuration");
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Bot Event Management",
                    Version = "v1",
                    Description = "API to manage events",
                });
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "BotEventManagement.Api.xml");

                Console.WriteLine($"Configure Services - Directory: {xmlPath}");

                c.IncludeXmlComments(xmlPath);
            });

            Console.WriteLine("Configure Services - Before Dependency Injection Configuration");

            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IEventParticipantService, EventParticipantsService>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<IUserTalksService, UserTalksService>();
            services.AddScoped<ISpeakerService, SpeakerService>();

            services.AddHealthChecks().AddSqlServer(Configuration["DefaultConnection"]);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Console.WriteLine("Configure Services - Before Environment Configuration");

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseHttpsRedirection();

            Console.WriteLine("Configure Services - Before Middleware Configuration");
            app.UseMiddleware<ErrorHandlingMiddleware>();

            Console.WriteLine("Configure Services - Before Update Database Configuration");
            UpdateDatabase(app);

            Console.WriteLine("Configure Services - Before Swagger Json Configuration");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bot Event Management V1");
                c.RoutePrefix = "";
            });

            app.UseHealthChecks("/status", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
            {

                ResponseWriter = WriteResponse
            });
            app.UseMvc();
        }

        private static Task WriteResponse(HttpContext httpContext,
    HealthReport result)
        {
            httpContext.Response.ContentType = "application/json";

            var json = new JObject(
                new JProperty("status", result.Status.ToString()),
                new JProperty("results", new JObject(result.Entries.Select(pair =>
                    new JProperty(pair.Key, new JObject(
                        new JProperty("status", pair.Value.Status.ToString()),
                        new JProperty("description", pair.Value.Description),
                        new JProperty("data", new JObject(pair.Value.Data.Select(
                            p => new JProperty(p.Key, p.Value))))))))));
            return httpContext.Response.WriteAsync(
                json.ToString(Formatting.Indented));
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<BotEventManagementContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
