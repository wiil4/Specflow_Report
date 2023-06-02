using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Net;
using System.Text.Json.Nodes;
using TechTalk.SpecFlow;

namespace SpecFlowPj
{
    [Binding]
    public class GetPostsStepDefinitions
    {
        RestClient client;
        RestRequest request;
        RestResponse response;

        [Given(@"a valid API endpoint")]
        public void GivenAValidAPIEndpoint()
        {
            client = new RestClient("http://34.125.117.44:3000");            
        }

        [Given(@"I have an id with value (.*)")]
        public void GivenIHaveAnIdWithValue(int p0)
        {
            request = new RestRequest("posts/{postid}", Method.Get);
            request.AddUrlSegment("postid", p0);
        }        

        [When(@"I send a request")]
        public void WhenISendARequest()
        {
            response = client.ExecuteGet(request);            
        }

        [Then(@"I expect a valid code response")]
        public void ThenIExpectAValidCodeResponse()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var jsonObject = JObject.Parse(response.Content);
            var result = jsonObject.SelectToken("title").ToString();
            Assert.That(result, Is.EqualTo("json-server"), "Title is not correct");
        }
    }
}
