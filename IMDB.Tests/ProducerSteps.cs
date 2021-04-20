using IMDBAPI;
using TechTalk.SpecFlow;

namespace IMDB.Tests
{
    [Scope(Feature = "Producer Resource")]
    [Binding]
    public class ProducerSteps : ProducerBaseSteps
    {
        public ProducerSteps(CustomWebApplicationFactory<TestStartup> factory)
            : base(factory)

        {

        }

        [BeforeScenario]
        public void MockRepositories()
        {
            ProducerMock.MockInitialize();
        }
    }
}
