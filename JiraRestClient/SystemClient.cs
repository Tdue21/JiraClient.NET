using JiraRestClient.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace JiraRestClient
{
    public class SystemClient :BaseClient
    {

        public SystemClient(HttpClient client, Uri baseUri)
        {
            this.client = client;
            this.baseUri = baseUri;
        }

        public ServerInfo GetServerInfo()
        {
            Uri uri = new Uri(baseUri, RestPathConstants.SERVER_INFO);
            using (Stream s = client.GetStreamAsync(uri).Result)
            using (StreamReader sr = new StreamReader(s, Encoding.UTF8))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                return serializer.Deserialize<ServerInfo>(reader);
            }
        }

        public List<Status> GetStates()
        {
            Uri uri = new Uri(baseUri, RestPathConstants.STATUS);
            using (Stream s = client.GetStreamAsync(uri).Result)
            using (StreamReader sr = new StreamReader(s, Encoding.UTF8))
            {
                string json = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Status>>(json);
            }
        }

        public List<IssueType> GetIssueTypes()
        {
            Uri uri = new Uri(baseUri, RestPathConstants.ISSUETPYES);
            using (Stream s = client.GetStreamAsync(uri).Result)
            using (StreamReader sr = new StreamReader(s, Encoding.UTF8))
            {
                string json = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<List<IssueType>>(json);
            }
        }

        public List<Priority> GetPriorities()
        {
            Uri uri = new Uri(baseUri, RestPathConstants.PRIORITY);
            using (Stream s = client.GetStreamAsync(uri).Result)
            using (StreamReader sr = new StreamReader(s, Encoding.UTF8))
            {
                string json = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Priority>>(json);
            }
        }
    }
}
