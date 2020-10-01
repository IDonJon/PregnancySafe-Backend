using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PregnancySafe.Domain.Repositories;
using PregnancySafe.Domain.Services;
using PregnancySafe.Persistence.Context;
using PregnancySafe.Persistence.Repositories;
using PregnancySafe.Services;

namespace PregnancySafe
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
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySQL("server=localhost; database=pregnacysafedb; user=root; password=992424558");
            });

            services.AddMvc();

            services.AddSwaggerGen(p =>
            {
                p.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Pregnancy Safe",
                    Description = "Proyecto de Aplicaciones Web"
                });
            });
            services.AddControllers();
            
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySQL("server=localhost; database=pregnacysafedb; user=root; password=992424558");
            });

            //Advice
            services.AddScoped<IAdviceRepository, AdviceRepository>();
            services.AddScoped<IAdviceService, AdviceService>();
           
            //Mother
            services.AddScoped<IMotherRepository, MotherRepository>();
            services.AddScoped<IMotherService, MotherService>();

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(p =>
            {
                p.SwaggerEndpoint("/swagger/v1/swagger.json", "Pregnancy Safe V1");
                p.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}