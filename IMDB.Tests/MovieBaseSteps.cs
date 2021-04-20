using System;
using Microsoft.AspNetCore.Mvc.Testing;

namespace IMDB.Tests.Steps
{
    public class MovieBaseSteps
    {
        public MovieBaseSteps()
        {
        }

        public MovieBaseSteps(WebApplicationFactory<TestStartup> webApplicationFactory)
        {
            WebApplicationFactory = webApplicationFactory;
        }

        public WebApplicationFactory<TestStartup> WebApplicationFactory { get; }
    }
}
