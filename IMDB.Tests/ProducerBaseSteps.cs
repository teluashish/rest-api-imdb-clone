using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using TechTalk.SpecFlow;
using Xunit;
using Microsoft.Extensions.DependencyInjection;

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

        [Given(@"I am Client")]
        public void GivenIAmClient()
        {
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
            ProducerMock.MockInitialize();

        }


        [When(@"I make POST Request to endpoint '(.*)' with body message '(.*)'")]
        public virtual async Task WhenIMakePOSTRequestToEndpointWithBodyMessage(string resourceEndPoint, string dataJson)
        {
            var postRelativeUri = new Uri(resourceEndPoint, UriKind.Relative);
            var content = new StringContent(dataJson, Encoding.UTF8, "application/json");
            _httpResponseMessage = await _client.PostAsync(postRelativeUri, content).ConfigureAwait(false);
        }



        [Then(@"the response status code is '(\d*)'")]
        public void ThenTheResponseStatusCodeIs(int statusCode)
        {
            var expectedStatusCode = (System.Net.HttpStatusCode)statusCode;
            Assert.Equal(expectedStatusCode, _httpResponseMessage.StatusCode);
        }


        //deleting a non-existing producer
        [When(@"I make DELETE Request '(.*)'")]
        public virtual async Task WhenIMakeDELETERequest(string resourceEndPoint)
        {
            var postRelativeUri = new Uri(resourceEndPoint, UriKind.Relative);
            _httpResponseMessage = await _client.DeleteAsync(postRelativeUri).ConfigureAwait(false);
        }




        [When(@"I make GET Request '(.*)'")]
        public virtual async Task WhenIMakeGETRequest(string resourceEndPoint)
        {
            var postRelativeUri = new Uri(resourceEndPoint, UriKind.Relative);
            _httpResponseMessage = await _client.GetAsync(postRelativeUri).ConfigureAwait(false);

        }

        [Then(@"response data must look like this '(.*)'")]
        public void ThenResponseDataMustLookLikeThis(string expectedResponse)
        {
            var responseData = _httpResponseMessage.Content.ReadAsStringAsync().Result;
            Assert.Equal(expectedResponse, responseData);

        }


        //updating non-existing producer
        [When(@"I make PUT Request to endpoint '(.*)' with body message '(.*)'")]
        public virtual async Task WhenIMakePUTRequestToEndpointWithBodyMessage(string resourceEndPoint, string dataJson)
        {
            var postRelativeUri = new Uri(resourceEndPoint, UriKind.Relative);
            var content = new StringContent(dataJson, Encoding.UTF8, "application/json");
            _httpResponseMessage = await _client.PutAsync(postRelativeUri, content).ConfigureAwait(false);
        }



    }
}
