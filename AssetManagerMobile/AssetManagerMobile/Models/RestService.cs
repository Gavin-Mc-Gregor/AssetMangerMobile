using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagerMobile.Models
{
    public class RestService
    {
        HttpClient client;
        private string grant_type = "password";
        private object retrun;

        public RestService()
        {
        }

        public RestService(HttpClient client)
        {
            this.client = client;
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-from-urlencoded' "));

        }
        public async Task<CToken> Login(CUser user)
        {
            var postData = new List<KeyValuePair<string,string>>();
            postData.Add(new KeyValuePair<string, string>("grant_Type", grant_type));
            postData.Add(new KeyValuePair<string, string>("username", user.Username));
            postData.Add(new KeyValuePair<string, string>("password", user.Password));
            var content = new FormUrlEncodedContent(postData);
            var response = await PostResponseLogin<CToken>(CConstants.LoginUrl, content);
            DateTime dt = new DateTime();
            dt = DateTime.Today;
            response.ExpityDate = dt.AddSeconds(response.ExpiresIn);
            return response;

        }
        public async Task<T> PostResponseLogin<T>(string webUrl, FormUrlEncodedContent content) where T : class
        {
          
            var response = await client.PostAsync(webUrl, content);
            var jsonResult = response.Content.ReadAsStringAsync().Result;
            var responseObject = JsonConvert.DeserializeObject<T>(jsonResult);
            return responseObject;
        }
        public async Task<T> PostResponse<T>(string webUrl, string jsonString) where T: class
        {
            var CToken = App.TokenDatabase.GetToken();
            string ContentType = "application/json";
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", CToken.AccessToken);
            var result = await client.PostAsync(webUrl, new StringContent(jsonString, Encoding.UTF8, ContentType));
            var jsonResult = result.Content.ReadAsStringAsync().Result;
            var contentResp = JsonConvert.DeserializeObject<T>(jsonResult);
            return contentResp;
        }
        public async Task<T> GetResponse<T>(string webUrl) where T: class
        {
            var Token = App.TokenDatabase.GetToken();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token.AccessToken);
            try
            {
                var response = await client.GetAsync(webUrl);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var JsonResult = response.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var contentResp = JsonConvert.DeserializeObject<T>(JsonResult);
                        return contentResp;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

   

    }
}
