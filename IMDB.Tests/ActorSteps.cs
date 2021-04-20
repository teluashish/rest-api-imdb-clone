using System;
using Microsoft.AspNetCore.Mvc;
using TechTalk.SpecFlow;
using Microsoft.Extensions.DependencyInjection;


namespace IMDB.Tests
{
    [Scope(Feature = "Actor Resource")]
    [Binding]
    public class ActorSteps:ActorBaseSteps
    {
        public ActorSteps(CustomWebApplicationFactory<TestStartup> factory):base(factory)
        {

        }

        [BeforeScenario]
        public void MockRepositories()
        {
            ActorMock.MockInitialize();
        }
    }
}
