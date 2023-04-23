using System;
using System.Data.Common;
using BetServices.Integration.Test.Seeders;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using WebAPI;

namespace BetServices.Integration.Test.Hooks
{
    public class TestServerFixture : WebApplicationFactory<Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            var pathToContentRoot = AppDomain.CurrentDomain.BaseDirectory;
            var configurationRoot = new ConfigurationBuilder()
                .SetBasePath(pathToContentRoot)
                .AddEnvironmentVariables()
                .Build();

            var hostBuilder = base.CreateHostBuilder()
                .UseEnvironment("Testing")
                .ConfigureAppConfiguration(config => config.AddConfiguration(configurationRoot));

            return hostBuilder;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(collection =>
            {
                collection.Remove(new ServiceDescriptor(typeof(DbConnection), serviceProvider => 
                    serviceProvider.GetService(typeof(MySqlConnection)), ServiceLifetime.Singleton));
                collection.AddSingleton<DbConnection, MySqlConnection>(_ => MySqlSeeder.Connection);
            });
            
            base.ConfigureWebHost(builder);
        }
    }
}