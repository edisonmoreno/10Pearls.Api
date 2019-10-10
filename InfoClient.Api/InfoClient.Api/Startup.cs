using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using InfoClient.DM.Database;
using InfoClient.DM.Client;
using InfoClient.BM.Client;
using Microsoft.EntityFrameworkCore;
using InfoClient.DM.Country;
using InfoClient.BM.Country;
using InfoClient.DT.Utilities;
using InfoClient.DM.Representative;
using InfoClient.BM.Representative;
using InfoClient.DM.Visit;
using InfoClient.BM.Visit;

namespace InfoClient.Api
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
            //Configuration Entity
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<_10PearlBDClientContext>(options => options.UseSqlServer(connection));
            //Configuration Cors
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin", builder => builder
                .WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

            //Configuration for Automapper
            var config = new AutoMapper.MapperConfiguration(c => {
                c.AddProfile(new ApplicationProfile());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //Configuration Dependency Injecction
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IBMClient, BMClient>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IBMCountry, BMCountry>();
            services.AddScoped<IRepresentativeRepository, RepresentativeRepository>();
            services.AddScoped<IBMRepresentative, BMRepresentative>();
            services.AddScoped<IVisitRepository, VisitRepository>();
            services.AddScoped<IBMVisit, BMVisit>();
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

            app.UseCors("AllowOrigin");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
