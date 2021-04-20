using System;
using Microsoft.AspNetCore.Mvc;
using TechTalk.SpecFlow;
using Microsoft.Extensions.DependencyInjection;
using IMDB.Tests.Steps;

namespace IMDB.Tests
{
    [Scope(Feature = "Producer Resource")]
    [Binding]
    public class ProducerSteps : ProducerBaseSteps
    {
        public ProducerSteps(CustomWebApplicationFactory<TestStartup> factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(services => ProducerMock.producerRepoMock.Object);
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
