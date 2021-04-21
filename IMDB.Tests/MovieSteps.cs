using IMDBAPI;
using TechTalk.SpecFlow;
using Microsoft.Extensions.DependencyInjection;

namespace IMDB.Tests
{
    [Scope(Feature = "MovieFeature")]
    [Binding]
    public class MovieSteps : BaseSteps
    {
        public MovieSteps(CustomWebApplicationFactory<TestStartup> factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(service => MovieMock.movieRepoMock.Object);
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
