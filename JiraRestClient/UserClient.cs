using JiraRestClient.Domain;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;

namespace JiraRestClient
{
    public class UserClient
    {
        private readonly HttpClient client;

        private readonly Uri baseUri;

        public UserClient(HttpClient client, Uri baseUri)
        {
            this.client = client;
            this.baseUri = baseUri;
        }

        public User GetUser(string username)
        {
            Uri url = new Uri(baseUri, RestPathConstants.USER);
            Uri final = UriHelper.AddQuery(url, RestParamConstants.USERNAME, username);
            using (Stream s = client.GetStreamAsync(final).Result)
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                JsonSerializer serializer = new JsonSerializer();
                return serializer.Deserialize<User>(reader);
            }
        }

    }
}
