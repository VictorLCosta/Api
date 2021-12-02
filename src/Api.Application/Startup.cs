using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Crosscutting.DependecyInjection;
using Api.Data.Transactions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace application
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddDataDependecies(_config);
            services.AddServiceDependecies(_config);

            services.AddControllers();
            services.AddApiVersioning(cfg =>
            {
                cfg.ReportApiVersions = true;
                cfg.AssumeDefaultVersionWhenUnspecified = true;
                cfg.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
            });
            services.AddSwaggerGen(c =>
            {
                c.ResolveConflictingActions(apiDescription => apiDescription.First());
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "application", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                await next.Invoke();

                var unitOfWork = (IUow)context.RequestServices.GetService(typeof(IUow));
                await unitOfWork.Commit();
                unitOfWork.Dispose();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "application v1");
                    c.RoutePrefix = "swagger";
                });
            }

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
