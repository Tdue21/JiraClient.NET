using JiraRestClient.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace JiraRestClient
{
    public class ProjectClient :BaseClient
    {

        public ProjectClient(HttpClient client, Uri baseUri)
        {
            this.client = client;
            this.baseUri = baseUri;
        }

        public Project GetProjectByKey(string key)
        {
            Uri uri = new Uri(baseUri, RestPathConstants.PROJECT);
            Uri final = UriHelper.AddIssueKey(uri, key);
            using (Stream s = client.GetStreamAsync(final).Result)
            using (StreamReader sr = new StreamReader(s, Encoding.UTF8))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                return serializer.Deserialize<Project>(reader);
            }
        }

        public List<Project> GetProjects()
        {
            Uri uri = new Uri(baseUri, RestPathConstants.PROJECT);
            using (Stream s = client.GetStreamAsync(uri).Result)
            using (StreamReader sr = new StreamReader(s, Encoding.UTF8))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                string json = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Project>>(json);
            }
        }
    }
}
