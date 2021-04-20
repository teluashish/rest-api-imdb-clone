using TechTalk.SpecFlow;

namespace IMDB.Tests
{
    [Scope(Feature = "Movie Resource")]
    [Binding]
    public class MovieSteps : MovieBaseSteps
    {
        public MovieSteps(CustomWebApplicationFactory<TestStartup> factory)
            : base(factory)

        {

        }

        [BeforeScenario]
        public void MockRepositories()
        {
            MovieMock.MockInitialize();
        }
    }
}
