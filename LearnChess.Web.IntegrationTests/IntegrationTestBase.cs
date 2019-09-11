using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using NUnit.Framework;

namespace LearnChess.Web.IntegrationTests
{
    public abstract class IntegrationTestBase
    {
        private WebApplicationFactory <Startup> factory;

        [SetUp]
        public void Setup()
        {
            factory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder => builder.UseSetting("BackendOnly", "true"));
        }

        protected async Task<T> Get<T>(string url, IDictionary<string, string> queryParams = null)
        {
            var client = factory.CreateClient();

            if (queryParams != null)
                url = QueryHelpers.AddQueryString(url, queryParams);
            
            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
        
        protected async Task<T> Post<T>(string url, object body)
        {
            var client = factory.CreateClient();

            var content = new StringContent(JsonConvert.SerializeObject(body));
            content.Headers.ContentType = new MediaTypeHeaderValue(MediaTypeNames.Application.Json);
                
            var response = await client.PostAsync(url, content);

            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
    }
}