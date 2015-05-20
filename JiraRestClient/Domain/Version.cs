using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraRestClient.Domain
{
    public class Version :Base
    {
        public string description { get; set; }
        public bool archived { get; set; }
        public bool released { get; set; }
        public bool overdue { get; set; }
        public string releaseDate { get; set; }
        public string userReleaseDate { get; set; }
    }
}
