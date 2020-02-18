using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using HoildayOptimizations.Integrations;
using HolidayOptimizations.Common.Helpers.Api;
using HolidayOptimizations.Service.Controllers;
using HolidayOptimizations.Service.Controllers.Helpers;
using HolidayOptimizations.Service.Entities.Configuration;
using HolidayOptimizations.Service.Processes;
using HolidayOptimizations.Service.Processes.Helpers;
using HolidayOptimizations.Service.Processes.Logger;
using HolidayOptimizations.StorageRepository.DataRepository.Features.Holidays;
using HolidayOptimizations.StorageRepository.DataRepositoryInterface.Features.Holidays;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ILogger = HolidayOptimizations.Service.Processes.Logger.ILogger;

namespace HolidayOptimizations
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            this.Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            StorageRepository.DataRepository.ConnectionString.Value = Configuration["ApplicationSettings:ConnectionString"];

            services.Configure<AppSettings>(Configuration.GetSection("ApplicationSettings"));
            services.AddSingleton<IAppSettings, AppSettings>();
            services.AddTransient<IHolidaysProcess, HolidaysService>();
            services.AddTransient<IHolidaysRepository, HolidaysRepository>();
            services.AddTransient<ITimezonesRepository, TimezonesRepository>();
            services.AddTransient<IHolidaysHelper, PublicHolidaysHelper>();
            services.AddTransient<INaggerClient, NaggerClient>();
            services.AddTransient<ILogger, Logger>();

            /* Swagger configuration */
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Holidays API", Version = "v1" });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services.ConfigureSwaggerGen(options =>
            {
                options.CustomSchemaIds(x => x.FullName);
            });
            /* Swagger configuration */

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            /* Swagger configuration */
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Holidays API v1");
            });
            /* Swagger configuration */

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
