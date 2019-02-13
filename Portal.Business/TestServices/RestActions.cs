using System;
using Newtonsoft.Json;

namespace Portal.Business.TestServices
{
    public class RestActions
    {
        private readonly string _contentRootPath;

        public RestActions(string contentRootPath)
        {
            _contentRootPath = contentRootPath;
        }

        public R CallRestAction<R, T>(T model, string url)
        {
            if (model == null) return default(R);
            var response = default(R);
            try
            {
                var restResponse = TestJsonHelper.PostRequest(_contentRootPath, url, model);

                if (restResponse.Content != null && restResponse.Content.Length > 0)
                {
                    response = JsonConvert.DeserializeObject<R>(restResponse.Content);
                }
            }
            catch (Exception ex)
            {
                Utilities.ManageExceptions.ProcessError(ex, _contentRootPath);
            }

            return response;
        }

        public R CallArmOneRestAction<R, T>(T model, string url, string token)
        {
            if (model == null) return default(R);
            var response = default(R);

            try
            {
                var restResponse = TestJsonHelper.ArmOnePostRequest(_contentRootPath, url, model, token);
                if (!string.IsNullOrEmpty(restResponse))
                {
                    response = JsonConvert.DeserializeObject<R>(restResponse);
                }
            }
            catch (Exception ex)
            {
                Utilities.ManageExceptions.ProcessError(ex, _contentRootPath);
            }

            return response;
        }

        public R CallArmOneRestTokenAction<R, T>(T model, string url)
        {
            if (model == null) return default(R);
            var response = default(R);

            try
            {
                var restResponse = TestJsonHelper.ArmOneTokenPostRequest(_contentRootPath, model, url);
                if (!string.IsNullOrEmpty(restResponse))
                {
                    response = JsonConvert.DeserializeObject<R>(restResponse);
                }
            }
            catch (Exception ex)
            {
                Utilities.ManageExceptions.ProcessError(ex, _contentRootPath);
            }

            return response;
        }

        public R ArmOneValidateCallAction<R, T>(T model, string url, string token, string sessionString)
        {
            if (model == null) return default(R);
            var response = default(R);

            try
            {
                var restResponse = TestJsonHelper.ArmOneTokenPostRequest(_contentRootPath, model, url, token, sessionString);
                if (!string.IsNullOrEmpty(restResponse))
                {
                    response = JsonConvert.DeserializeObject<R>(restResponse);
                }
            }
            catch (Exception ex)
            {
                Utilities.ManageExceptions.ProcessError(ex, _contentRootPath);
            }

            return response;
        }

        public R GetArmOneDetails<R>(string url)
        {
            if (url == null) return default(R);
            var response = default(R);

            try
            {
                var restResponse = TestJsonHelper.GetArmOneRequest(_contentRootPath, url);
                if (!string.IsNullOrEmpty(restResponse))
                {
                    response = JsonConvert.DeserializeObject<R>(restResponse);
                }
            }
            catch (Exception ex)
            {
                Utilities.ManageExceptions.ProcessError(ex, _contentRootPath);
            }

            return response;
        }
    }
}
