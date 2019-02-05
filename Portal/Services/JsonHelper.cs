using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace Portal.Services
{
    public class JsonHelper
    {
        private static IConfiguration configuration;
        public JsonHelper(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, 
            System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public static IRestResponse MakeRequest(string contentRootPath, string requestUrl, string headerHash, bool authenticationRequired = false, string username = "", string password = "")
        {
            try
            {
                IRestResponse response = new RestResponse();
                var client = new RestClient(requestUrl);
                if (authenticationRequired)
                {
                    client.Authenticator = new SimpleAuthenticator("username", username, "password", password);
                }
                var webRequest = new RestRequest(Method.GET);
                if (headerHash != null && headerHash.Length > 0)
                {
                    webRequest.AddHeader("hash", headerHash);
                }
                Task.Run(async () =>
                {
                    response = await GetResponseContentAsync(client, webRequest) as RestResponse;
                }).Wait();
                return response;
            }
            catch (Exception ex)
            {
                Utilities.ProcessError(ex, contentRootPath);
                return null;
            }
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }

        public static IRestResponse PostRequest(string contentRootPath, string requestUrl, object data)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                IRestResponse response = new RestResponse();
                var client = new RestClient(requestUrl);
                var webRequest = new RestRequest(Method.POST)
                {
                    RequestFormat = DataFormat.Json
                };
                webRequest.AddHeader("content-type", "application/json");
                webRequest.AddParameter("application/json", json, ParameterType.RequestBody);
                Task.Run(async () =>
                {
                    response = await PostResponseContentAsync(client, webRequest) as RestResponse;
                }).Wait();
                return response;
            }
            catch (Exception ex)
            {
                Utilities.ProcessError(ex, contentRootPath);
                return null;
            }
        }

        public static string GetArmOneRequest(string contentRootPath, string requestUrl)
        {
            try
            {
                string response = String.Empty;
                var httpresponse = new HttpResponseMessage();
                HttpClient webclient = new HttpClient();
                var url = new Uri(requestUrl);

                var task = GetArmOneContentAsync(url, webclient);
                httpresponse = task.Result;

                using (HttpContent rescontent = httpresponse.Content)
                {
                    Task<string> res = rescontent.ReadAsStringAsync();
                    response = res.Result;

                    return response;
                }
            }
            catch (Exception ex)
            {
                Utilities.ProcessError(ex, contentRootPath);
                return null;
            }
        }

        public static string ArmOnePostRequest(string contentRootPath, string requestUrl, object data, string token)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var httpresponse = new HttpResponseMessage();
                var response = string.Empty;

                HttpClient webclient = new HttpClient();
                var url = new Uri(requestUrl);

                webclient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", token);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var task = PostArmOneContentAsync(url, content, webclient);
                httpresponse = task.Result;
                using (HttpContent rescontent = httpresponse.Content)
                {
                    Task<string> res = rescontent.ReadAsStringAsync();
                    response = res.Result;

                    return response;
                }
            }
            catch (Exception ex)
            {
                Utilities.ProcessError(ex, contentRootPath);
                return null;
            }
        }

        public static string ArmOneTokenPostRequest(string contentRootPath, object data, string requestUrl, string token = null, string sessionString = null)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var httpresponse = new HttpResponseMessage();
                var response = string.Empty;

                HttpClient webclient = new HttpClient();
                var url = new Uri(requestUrl);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                if (!String.IsNullOrEmpty(sessionString))
                    webclient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", sessionString);
                if (!String.IsNullOrEmpty(token))
                    webclient.DefaultRequestHeaders.TryAddWithoutValidation("Token", token);

                var task = PostArmOneContentAsync(url, content, webclient);
                httpresponse = task.Result;
                using (HttpContent rescontent = httpresponse.Content)
                {
                    Task<string> res = rescontent.ReadAsStringAsync();
                    response = res.Result;

                    return response;
                }
            }
            catch (Exception ex)
            {
                Utilities.ProcessError(ex, contentRootPath);
                return null;
            }
        }

        public static Task<HttpResponseMessage> PostArmOneContentAsync(Uri url, StringContent content, HttpClient client)
        {
            var task = Task.Run(async () =>
            {
                return await client.PostAsync(url, content);
            });
            return task;
        }

        public static Task<HttpResponseMessage> GetArmOneContentAsync(Uri url, HttpClient client)
        {
            var task = Task.Run(async () =>
            {
                return await client.GetAsync(url);
            });
            return task;
        }

        public static Task<IRestResponse> PostResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
