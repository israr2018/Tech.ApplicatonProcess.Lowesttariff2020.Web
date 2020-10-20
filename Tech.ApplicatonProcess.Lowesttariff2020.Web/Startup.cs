using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tech.ApplicatonProcess.Lowesttariff2020.Web.Data;
using Microsoft.EntityFrameworkCore;
using Tech.ApplicatonProcess.Lowesttariff2020.Web.Repositories;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using AutoMapper;
using System;

namespace Tech.ApplicatonProcess.Lowesttariff2020.Web
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
            //services.AddCors(options =>
            //{
            //    options.AddPolicy(name: "AllowedAngularApp",
            //                      builder =>
            //                      {
            //                          builder.WithOrigins("http://localhost:4200");
            //                      });
            //});
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TechApplication Process 2020 ", Version = "v1" });
            });
            
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IApplicationRepo, ApplicationRepo>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            

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
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TechApplication Process 2020 V1");
            });
            


        }
    }
}
