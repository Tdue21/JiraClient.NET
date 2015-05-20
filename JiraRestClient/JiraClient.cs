using System;
using System.Net.Http;
using System.Text;

namespace JiraRestClient
{
    public class JiraClient
    {
        private readonly Uri baseUri;
        private readonly HttpClient client;

        private UserClient _userClient;

        private SystemClient _systemClient;

        private IssueClient _issueClient;

        private SearchClient _searchClient;

        private ProjectClient _projectClient;

        public JiraClient(Uri uri, String username, String password)
        {
            this.baseUri = new Uri(uri, RestPathConstants.BASE_REST_PATH);
            this.client = new HttpClient();
            var byteArray = Encoding.UTF8.GetBytes(username + ":" + password);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }


        public SystemClient SystemClient
        {
            get {
                if (_systemClient == null)
                {
                    _systemClient = new SystemClient(client, baseUri);
                }
                return _systemClient;
            }
        }

        public UserClient UserClient
        {
            get{
                if (_userClient == null)
                {
                    _userClient = new UserClient(client, baseUri);
                }
                return _userClient;
            }       
        }

        public IssueClient IssueClient
        {
            get
            {
                if (_issueClient == null)
                {
                    _issueClient = new IssueClient(client, baseUri);
                }
                return _issueClient;
            }
        }

        public SearchClient SearchClient
        {
            get
            {
                if (_searchClient == null)
                {
                    _searchClient = new SearchClient(client, baseUri);
                }
                return _searchClient;
            }
        }

        public ProjectClient ProjectClient
        {
            get
            {
                if (_projectClient == null)
                {
                    _projectClient = new ProjectClient(client, baseUri);
                }
                return _projectClient;
            }
        }

    }
}
