using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraRestClient.Domain
{
    public class Base
    {
        public long id { get; set; }
        public string self { get; set; }
        public string name { get; set; }
    }

    public class Key : Base
    {
        public string key { get; set; }
    }
}
