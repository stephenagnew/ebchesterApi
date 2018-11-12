using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EbchesterApi.Controllers.Error;
using EbchesterApi.Models;
using EbchesterApi.Repositories;
using EbchesterApi.Repositories.Interfaces;
using EbchesterApi.Services;
using EbchesterApi.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EbchesterApi
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
            //Mongo setup
            services.AddSingleton(sp => new MongoClient(Configuration.GetSection("MongoConnection:ConnectionString").Value));
            services.AddSingleton(sp => sp.GetService<MongoClient>().GetDatabase(Configuration.GetSection("MongoConnection:Database").Value));
            services.AddSingleton(sp => sp.GetService<IMongoDatabase>().GetCollection<Match>("Matches"));
            services.AddSingleton(sp => sp.GetService<IMongoDatabase>().GetCollection<Player>("Players"));

            //DI services setup
            services.AddTransient<IMatchService, MatchService>();
            services.AddTransient<IMatchRepository, MatchRepository>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();

            //Cors
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials()));

            //Add Authentication

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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

            //Authentication goes here 
            app.UseMiddleware(typeof(GlobalErrorHandler));
            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
