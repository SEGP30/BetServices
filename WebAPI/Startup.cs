using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetServices.Domain.Contracts;
using BetServices.Infrastructure;
using BetServices.Infrastructure.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;

namespace WebAPI
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
            services.AddDbContext<DbContext, BetServicesContext>
            (opt => opt.UseMySQL($"Server = localhost; Port = 0330; Database = Bet_Services ; Username = root ; Password = mementomori1"),
                ServiceLifetime.Transient
            );
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" }); });
            
            // var multiplexer = ConnectionMultiplexer.Connect("localhost:6379");
            // services.AddSingleton<IConnectionMultiplexer>(multiplexer);

            //services.AddStackExchangeRedisCache(options => { options.Configuration = "localhost:6379"; });

            /* services.AddStackExchangeRedisCache(options => { options.Configuration = Configuration.GetValue<string> ("Redis:Server");
                    Configuration.GetValue<int> ("Redis:Port"); }); */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}