using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotEventManagement.Services.Model.Database;
using BotEventManagement.Web.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using StackExchange.Redis;

namespace BotEventManagement.Web
{
    public class Startup
    {
        private readonly string _errorDefaultPath = "/Home/Error";
        public Startup(IHostingEnvironment environment)
        {

            //Put Configurations to read values from Environment variables
            Configuration = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var apiUrl = $"http://{Configuration["EventManagerApiUrl"]}";

            Console.WriteLine($"Machine Name: {Environment.MachineName}");

            if (!string.IsNullOrEmpty(Configuration["RedisDatabaseUrl"]) &&
                !string.IsNullOrEmpty(Configuration["RedisDatabasePort"]) &&
                !string.IsNullOrEmpty(Configuration["RedisDatabasePassword"]))
            {
                Console.WriteLine("Configuring REDIS Connection");

                var redisStringConnection = $"{Configuration["RedisDatabaseUrl"]}:{Configuration["RedisDatabasePort"]},password={Configuration["RedisDatabasePassword"]},ssl=True,abortConnect=False";

                var redis = ConnectionMultiplexer.Connect(redisStringConnection);
                services.AddDataProtection().PersistKeysToStackExchangeRedis(redis, $"DataProtection-Keys");
            }

            services.AddSingleton(RestEase.RestClient.For<IEventManagerApi>(apiUrl));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;

                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseForwardedHeaders();

            if (!string.IsNullOrEmpty(Configuration["BasePath"]))
                app.UsePathBase(Configuration["BasePath"]);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(_errorDefaultPath);
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
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
}
