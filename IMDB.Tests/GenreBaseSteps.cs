using System;
using Microsoft.AspNetCore.Mvc.Testing;

namespace IMDB.Tests.Steps
{
    public class GenreBaseSteps
    {
        public GenreBaseSteps()
        {
        }

        public GenreBaseSteps(WebApplicationFactory<TestStartup> webApplicationFactory)
        {
            WebApplicationFactory = webApplicationFactory;
        }

        public WebApplicationFactory<TestStartup> WebApplicationFactory { get; }
    }
}
