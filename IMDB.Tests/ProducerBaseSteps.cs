using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using TechTalk.SpecFlow;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using IMDBAPI;

namespace IMDB.Tests
{
    [Binding]
    public class ProducerBaseSteps
    {
        private readonly CustomWebApplicationFactory<TestStartup> _factory;
        private HttpClient _client;
        private HttpResponseMessage _httpResponseMessage;

        public ProducerBaseSteps(CustomWebApplicationFactory<TestStartup> webApplicationFactory)
        {
            _factory = (CustomWebApplicationFactory<TestStartup>)webApplicationFactory.WithWebHostBuilder(builder => builder.ConfigureServices(services =>
            {
                services.AddScoped(services => ProducerMock.producerRepoMock.Object);
            }));
        }






    }
}
