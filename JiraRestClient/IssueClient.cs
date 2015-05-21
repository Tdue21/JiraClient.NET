using JiraRestClient.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;

namespace JiraRestClient
{
    public class IssueClient :BaseClient
    {
        public IssueClient(HttpClient client, Uri baseUri)
        {
            this.client = client;
            this.baseUri = baseUri;
        }

        public Issue GetIssueByKey(string key)
        {
            try
            {
                Uri url = new Uri(baseUri, RestPathConstants.ISSUE);
                Uri final = UriHelper.AddIssueKey(url, key);
                using (Stream s = client.GetStreamAsync(final).Result)
                using (StreamReader sr = new StreamReader(s))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    return serializer.Deserialize<Issue>(reader);
                }
            }
            catch(HttpRequestException e)
            {
                Debug.WriteLine(e.StackTrace);
                return null;
            }

               
        }

        public Issue GetIssueByKey(string key, List<string> fields, List<string> expand)
        {
            Uri url = new Uri(baseUri, RestPathConstants.ISSUE);
            Uri final = UriHelper.AddIssueKey(url, key);
            if (fields.Count > 0)
            {
                string joined = string.Join(",", fields.ToArray());
                final = UriHelper.AddQuery(final, RestParamConstants.FIELDS, joined);
            }
            if (expand.Count > 0)
            {
                string joined = string.Join(",", expand.ToArray());
                final = UriHelper.AddQuery(final, RestParamConstants.EXPAND, joined);
            }
            using (Stream s = client.GetStreamAsync(final).Result)
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                return serializer.Deserialize<Issue>(reader);
            }
        }

        public Issue CreateIssue(Issue issue)
        {
            throw new NotImplementedException();
        }



    }
}
