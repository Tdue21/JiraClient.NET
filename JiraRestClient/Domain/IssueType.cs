using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraRestClient.Domain
{
    public class IssueType : Base
    {
        public string description { get; set; }
        public string iconUrl { get; set; }
        public bool subtask { get; set; }
    }
}
