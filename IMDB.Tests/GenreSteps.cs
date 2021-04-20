using TechTalk.SpecFlow;

namespace IMDB.Tests
{
    [Scope(Feature = "Genre Resource")]
    [Binding]
    public class GenreSteps : GenreBaseSteps
    {
        public GenreSteps(CustomWebApplicationFactory<TestStartup> factory)
            : base(factory)

        {

        }

        [BeforeScenario]
        public void MockRepositories()
        {
            GenreMock.MockInitialize();
        }
    }
}
