using IMDBAPI;
using TechTalk.SpecFlow;
using Microsoft.Extensions.DependencyInjection;
namespace IMDB.Tests
{
    [Scope(Feature = "ProducerFeature")]
    [Binding]
    public class ProducerSteps : BaseSteps
    {
        public ProducerSteps(CustomWebApplicationFactory<TestStartup> factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(service => ProducerMock.producerRepoMock.Object);
                });

            }))

        {

        }

        [BeforeScenario]
        public void MockRepositories()
        {
            ProducerMock.MockInitialize();
        }
    }
}
