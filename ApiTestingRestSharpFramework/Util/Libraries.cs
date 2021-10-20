using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Serialization.Json;
using Newtonsoft.Json.Linq;

namespace ApiTestingRestSharpFramework.Util

{
    public static class Libraries
    {
        public async static Task<IRestResponse> ExecuteAsyncRequest<T>(this RestClient client, IRestRequest request) where T: class, new()
        {
            var taskComplettionSource = new TaskCompletionSource<IRestResponse<T>>();
            var response = await client.ExecuteAsync<T>(request);
            
            if (response.ErrorException != null)
            {
                const string message = "Error occured when trying to retrieve the response.";
                throw new ApplicationException(message, response.ErrorException);
            }

            return await taskComplettionSource.Task;
        }

        public static string GetResponseObject(this IRestResponse response, string key)
        {
            JObject obs = JObject.Parse(response.Content);
            return obs[key].ToString();
        }


    }
}
