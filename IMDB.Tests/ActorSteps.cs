using TechTalk.SpecFlow;
using Microsoft.Extensions.DependencyInjection;
using IMDBAPI;

namespace IMDB.Tests
{
    [Scope(Feature = "ActorFeature")]
    [Binding]
    public class ActorSteps:BaseSteps
    {
        public ActorSteps(CustomWebApplicationFactory<TestStartup> factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                  {
                      services.AddScoped(service => ActorMock.actorRepoMock.Object);
                  });

            }))
        {

        }
        [BeforeFeature]
        public static void MockRepositories()
        {
            ActorMock.MockInitialize();
        }
    }
}
