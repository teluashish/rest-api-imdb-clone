using System;
using Microsoft.AspNetCore.Mvc.Testing;

namespace IMDB.Tests.Steps
{
    public class ProducerBaseSteps
    {
        public ProducerBaseSteps()
        {
        }

        public ProducerBaseSteps(WebApplicationFactory<TestStartup> webApplicationFactory)
        {
            WebApplicationFactory = webApplicationFactory;
        }

        public WebApplicationFactory<TestStartup> WebApplicationFactory { get; }
    }
}
