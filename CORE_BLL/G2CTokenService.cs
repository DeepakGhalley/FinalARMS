using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CORE_DLL;
//using ARMS_BOL;
using CORE_BOL;

namespace CORE_BLL 
{

    public class G2CTokenService : IG2CTokenService
    {
        private G2CAPIToken token = new G2CAPIToken();
        private readonly IOptions<G2CAPISettings> G2CAPISettings;
        public G2CTokenService(IOptions<G2CAPISettings> oktaG2CSettings)
        {
           // this.DatahubSettings = oktaSettings;
            this.G2CAPISettings = oktaG2CSettings;
        }

        private async Task<G2CAPIToken> GetG2CNewAccessToken()
        {
            var token = new G2CAPIToken();
            var client = new HttpClient();
            var client_id = this.G2CAPISettings.Value.ClientId;
            var client_secret = this.G2CAPISettings.Value.ClientSecret;

            var clientCreds = System.Text.Encoding.UTF8.GetBytes($"{client_id}:{client_secret}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(clientCreds));

            var postMessage = new Dictionary<string, string>();
            postMessage.Add("grant_type", "client_credentials");
            postMessage.Add("scope", "access_token");
            var request = new HttpRequestMessage(HttpMethod.Post, this.G2CAPISettings.Value.TokenUrl)
            {
                Content = new FormUrlEncodedContent(postMessage)
            };

            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                this.token = JsonConvert.DeserializeObject<G2CAPIToken>(json);
                token = this.token;
                this.token.ExpiresAt = DateTime.UtcNow.AddSeconds(this.token.ExpiresIn);
            }
            else
            {
                throw new ApplicationException("Unable to retrieve access token from Okta");
            }

            return token;
        }
        public async Task<G2CAPIToken> GetG2CToken()
        {
            if (!this.token.IsValidAndNotExpiring)
            {
                this.token = await GetG2CNewAccessToken();
            }
            return token;
        }


    }
}
//        private DatahubToken token = new DatahubToken();
//        private readonly IOptions<DatahubSettings> DatahubSettings;

//        public DatahubTokenService(IOptions<DatahubSettings> oktaSettings)
//        {
//            this.DatahubSettings = oktaSettings;
//        }
//        async Task<DatahubToken> GetToken()
//        {
//            if (!this.token.IsValidAndNotExpiring)
//            {
//                this.token = await this.GetNewAccessToken();
//            }
//            return token;
//        }
//        //public async Task<DatahubToken> GetToken()
//        //{
//        //    if (!this.token.IsValidAndNotExpiring)
//        //    {
//        //        this.token = await this.GetNewAccessToken();
//        //    }
//        //    return token;
//        //}     
//        private async Task<DatahubToken> GetNewAccessToken()
//        {
//            var token = new DatahubToken();
//            var client = new HttpClient();
//            var client_id = this.DatahubSettings.Value.ClientId; 
//            var client_secret = this.DatahubSettings.Value.ClientSecret;

//            var clientCreds = System.Text.Encoding.UTF8.GetBytes($"{client_id}:{client_secret}");
//            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(clientCreds));

//            var postMessage = new Dictionary<string, string>();
//            postMessage.Add("grant_type", "client_credentials");
//            postMessage.Add("scope", "access_token");
//            var request = new HttpRequestMessage(HttpMethod.Post, this.DatahubSettings.Value.TokenUrl)
//            {
//                Content = new FormUrlEncodedContent(postMessage)
//            };

//            var response = await client.SendAsync(request);
//            if (response.IsSuccessStatusCode)
//            {
//                var json = await response.Content.ReadAsStringAsync();
//                this.token = JsonConvert.DeserializeObject<DatahubToken>(json);
//                token = this.token;
//                this.token.ExpiresAt = DateTime.UtcNow.AddSeconds(this.token.ExpiresIn);
//            }
//            else
//            {
//                throw new ApplicationException("Unable to retrieve access token.");
//            }

//            return token;
//        }

//        async Task<ARMS_BOL.DatahubToken> ITokenService.GetToken()
//        {
//            if (!this.token.IsValidAndNotExpiring)
//            {
//                this.token = await this.GetNewAccessToken();
//            }
//            return token;
//        }

//        private class DatahubToken 
//        {
//            [JsonProperty(PropertyName = "access_token")]
//            public string AccessToken { get; set; } 

//            [JsonProperty(PropertyName = "expires_in")]
//            public long ExpiresIn { get; set; }

//            public DateTime ExpiresAt { get; set; }
//            [JsonProperty(PropertyName = "scope")]
//            public string Scope { get; set; }

//            [JsonProperty(PropertyName = "token_type")]
//            public string Token_Type { get; set; } 

//            public bool IsValidAndNotExpiring
//            {
//                get
//                {

//                   // return !String.IsNullOrEmpty(this.AccessToken);// && this.ExpiresAt > DateTime.UtcNow.AddSeconds(30);
//                    return !String.IsNullOrEmpty(this.AccessToken) && this.ExpiresAt > DateTime.UtcNow.AddSeconds(30);
//                }
//            }
//        }
//    }
//}