using System;
using Microsoft.AspNetCore.Mvc;
using TechTalk.SpecFlow;
using Microsoft.Extensions.DependencyInjection;
using IMDB.Tests.Steps;

namespace IMDB.Tests
{
    [Scope(Feature = "Movie Resource")]
    [Binding]
    public class MovieSteps : MovieBaseSteps
    {
        public MovieSteps(CustomWebApplicationFactory<TestStartup> factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(services => MovieMock.movieRepoMock.Object);
                });
            }))

        {

        }

        [BeforeScenario]
        public void MockRepositories()
        {
            MovieMock.MockInitialize();
        }
    }
}
