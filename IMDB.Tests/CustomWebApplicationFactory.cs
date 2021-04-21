using System;
using IMDBAPI;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;




namespace IMDB.Tests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TestStartup>
    {
        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            // Set the environment as 'Testing '
            return WebHost.CreateDefaultBuilder()
                    .UseEnvironment("Testing")
                        .UseStartup<TestStartup>();
        }
    }

}