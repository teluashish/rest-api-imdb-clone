using System;
using Microsoft.AspNetCore.Mvc;
using TechTalk.SpecFlow;
using Microsoft.Extensions.DependencyInjection;
using IMDB.Tests.Steps;

namespace IMDB.Tests
{
    [Scope(Feature = "Genre Resource")]
    [Binding]
    public class GenreSteps : GenreBaseSteps
    {
        public GenreSteps(CustomWebApplicationFactory<TestStartup> factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(services => GenreMock.genreRepoMock.Object);
                });
            }))

        {

        }

        [BeforeScenario]
        public void MockRepositories()
        {
            GenreMock.MockInitialize();
        }
    }
}
