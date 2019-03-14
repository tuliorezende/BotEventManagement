using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotEventManagement.Web.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace BotEventManagement.Web
{
    public class Startup
    {
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
            Console.WriteLine($"URL de API: {apiUrl}");

            services.AddDataProtection(options =>
            {
                options.ApplicationDiscriminator = "eventmanager.ui";
            });

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

            var logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                 .WriteTo.Console()
                 .CreateLogger();

            app.Use(async (context, next) =>
            {
                logger.Information("WEBVIEW - Log Requisition Informations!!");

                // Request method, scheme, and path
                logger.Information("Request Method: {METHOD}", context.Request.Method);
                logger.Information("Request Scheme: {SCHEME}", context.Request.Scheme);
                logger.Information("Request Path: {PATH}", context.Request.Path);
                logger.Information("Request Path Base: {PATHBASE}", context.Request.PathBase);
                // Headers
                foreach (var header in context.Request.Headers)
                    logger.Information("Header: {KEY}: {VALUE}", header.Key, header.Value);

                // Connection: RemoteIp
                logger.Information("Request RemoteIp: {REMOTE_IP_ADDRESS}",
                    context.Connection.RemoteIpAddress);

                await next();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
