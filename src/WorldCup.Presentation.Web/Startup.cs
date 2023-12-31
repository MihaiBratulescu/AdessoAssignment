﻿using Microsoft.OpenApi.Models;
using Serilog;
using WorldCup.Infrastructure;

namespace WorldCup.Presentation.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "World Cup API",
                });
            });

            services.AddLogger();
            services.AddCaching();
            services.AddHandler();
            services.AddDbContext();
            services.AddApplicationServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            DevelopmentSetup(app, env);

            app.UseHttpsRedirection();
            app.UseRouting();

            //should add an error handler middleware

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSerilogRequestLogging();
        }

        private static void DevelopmentSetup(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseHsts();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                });
                app.UseDeveloperExceptionPage();
            }
        }
    }
}
