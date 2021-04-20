using IMDBAPI;
namespace IMDB.Tests
{
    public class GenreBaseSteps
    {
        private readonly CustomWebApplicationFactory<TestStartup> _factory;


        public GenreBaseSteps(CustomWebApplicationFactory<TestStartup> webApplicationFactory)
        {
            _factory = webApplicationFactory;
        }
    }
}