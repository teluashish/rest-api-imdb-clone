using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace IMDB.Tests
{
	public class CustomWebApplicationFactory<TestStartup> : WebApplicationFactory<TestStartup> where TestStartup:class
	{
		protected override IHostBuilder CreateHostBuilder()
		{
			return base.CreateHostBuilder().ConfigureWebHostDefaults(webBuilder => {
				webBuilder.UseStartup<TestStartup>();
			});
		}
	}
}
