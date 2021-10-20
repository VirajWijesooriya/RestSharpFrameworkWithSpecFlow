using ApiTestingRestSharpFramework.Model;
using ApiTestingRestSharpFramework.Util;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiTestingRestSharpFramework
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestAsyncGet()
        {
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("posts/1", Method.GET);

            var response = client.ExecuteGetAsync<Posts>(request).GetAwaiter().GetResult();

            var deserialize = new JsonDeserializer();
            var reponsedeser = deserialize.Deserialize<Dictionary<string, string>>(response);

            Assert.AreEqual("1", reponsedeser["id"], "Assertion Failed");
            Assert.AreEqual("json-server", reponsedeser["title"], "Assertion Failed");
            Assert.AreEqual("typicode", reponsedeser["author"], "Assertion Failed");
        }
        
        [Test]
        public void TestAsyncPost()
        {
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("posts", Method.POST, DataFormat.Json);

            var id = 16;
            Posts newPost = new Posts(id, "DemoTypeBody", "Viraj");
            request.AddJsonBody(newPost);

            var response = client.ExecutePostAsync<Posts>(request).GetAwaiter().GetResult();

            var deserialize = new JsonDeserializer();
            var reponsedeser = deserialize.Deserialize<Dictionary<string, string>>(response);

            Assert.AreEqual(id.ToString(), reponsedeser["id"], "Assertion Failed");
            Assert.AreEqual("DemoTypeBody", reponsedeser["title"], "Assertion Failed");
            Assert.AreEqual("Viraj", reponsedeser["author"], "Assertion Failed");
        }
    }
}
