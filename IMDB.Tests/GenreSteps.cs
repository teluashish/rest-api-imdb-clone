using TechTalk.SpecFlow;
using IMDBAPI;
using Microsoft.Extensions.DependencyInjection;
namespace IMDB.Tests
{
    [Scope(Feature = "GenreFeature")]
    [Binding]
    public class GenreSteps : BaseSteps
    {
        public GenreSteps(CustomWebApplicationFactory<TestStartup> factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(service => GenreMock.genreRepoMock.Object);
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
