using ApiTestingRestSharpFramework.Model;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using ApiTestingRestSharpFramework.Util;

namespace ApiTestingRestSharpFramework.Steps
{
    [Binding]
    class GetPostsSteps
    {
        public RestClient client = new RestClient("http://localhost:3000");
        public RestRequest request = new RestRequest();
        public IRestResponse<Posts> response = new RestResponse<Posts>();

        [Given(@"I perform GET operation for ""(.*)""")]
        public void GivenIPerformGETOperationFor(string url)
        {
            request = new RestRequest(url, Method.GET);
        }

        [Given(@"I perform operation for post ""(.*)""")]
        public void GivenIPerformOperationForPost(int postid)
        {
            request.AddUrlSegment("postid", postid.ToString());
            response = client.ExecuteGetAsync<Posts>(request).GetAwaiter().GetResult();
        }

        [Then(@"I should see the ""(.*)"" name as ""(.*)""")]
        public void ThenIShouldSeeTheNameAs(string key, string value)
        {
            var test = response.GetResponseObject(key);
            Assert.AreEqual(value, test, $"{key} Didn't match!!");
        }
    }
}
