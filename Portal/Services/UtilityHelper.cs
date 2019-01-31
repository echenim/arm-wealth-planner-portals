using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Portal.Services
{
    public class UtilityHelper
    {
        public UtilityHelper(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public string ARMOneToken()
        {
            HttpClient webclient = new HttpClient();

            SecureCredentials decrypt = new SecureCredentials();

            var uname = Configuration.GetSection("AppSettings").GetSection("ArmOneUsername").Value;
            var pass = Configuration.GetSection("AppSettings").GetSection("ArmOnePassword").Value;
            var Url = Configuration.GetSection("AppSettings").GetSection("ArmOneToken").Value;

            var Username = decrypt.DecryptCredentials(uname);
            var Password = decrypt.DecryptCredentials(pass);
            var EmailAddress = Configuration.GetSection("AppSettings").GetSection("ARMOneEmail").Value;

            Uri mUrl = new Uri(Url);
            string Token = "";

            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("Username", Username);
            data.Add("Password", Password);
            data.Add("EmailAddress", EmailAddress);

            var MySerializedObject = JsonConvert.SerializeObject(data);

            var content = new StringContent(MySerializedObject, Encoding.UTF8, "application/json");

            var task = Task.Run(async () =>
            {
                return await webclient.PostAsync(mUrl, content);
            });

            var response = task.Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                response.EnsureSuccessStatusCode();
                var task1 = Task.Run(async () =>
                {
                    return await response.Content.ReadAsStringAsync();
                });

                var rep = task1.Result;

                Dictionary<string, object> aoresult = JsonConvert.DeserializeObject<Dictionary<string, object>>(rep);

                aoresult.TryGetValue("CustomerReference", out object MK);
                Token = MK.ToString();
            }
            return Token;
        }

        public static IRestResponse PostArmOneRequest(string contentRootPath, string requestUrl, object data, string token)
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
                webRequest.AddHeader("Authorization", token);
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
