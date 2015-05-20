using JiraRestClient.Jql;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;

namespace JiraRestClient
{
    public class SearchClient :BaseClient
    {
        
        public SearchClient(HttpClient client, Uri baseUri)
        {
            this.client = client;
            this.baseUri = baseUri;
        }

        public JqlSearchResult SearchIssues(JqlSearchBean jqlsearchbean)
        {
            string json = JsonConvert.SerializeObject(jqlsearchbean, Formatting.Indented);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            Uri url = new Uri(baseUri, RestPathConstants.SEARCH);
            using (HttpResponseMessage result = client.PostAsync(url, content).Result)
            using (Stream s = result.Content.ReadAsStreamAsync().Result)
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                return serializer.Deserialize<JqlSearchResult>(reader);
            }
        }
    }
}
