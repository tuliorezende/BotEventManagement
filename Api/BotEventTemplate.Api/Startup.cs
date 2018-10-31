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

namespace BotEventTemplate.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<BotEventManagementContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
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
                c.IncludeXmlComments(xmlPath);
            });

            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IEventParticipantService, EventParticipantsService>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<IUserTalksService, UserTalksService>();
            services.AddScoped<ISpeakerService, SpeakerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseHttpsRedirection();
            app.UseMiddleware<ErrorHandlingMiddleware>();

            UpdateDatabase(app);

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bot Event Management V1");
                c.RoutePrefix = "";
            });

            app.UseMvc();
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
