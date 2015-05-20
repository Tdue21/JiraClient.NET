using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JiraRestClient
{
    public abstract class BaseClient
    {
        protected HttpClient client;

        protected Uri baseUri;

        protected JsonSerializer serializer = JsonSerializer.Create(new JsonSerializerSettings()
        {
            DateFormatHandling = DateFormatHandling.IsoDateFormat,
            DateParseHandling = Newtonsoft.Json.DateParseHandling.DateTimeOffset
        });

    }
}
