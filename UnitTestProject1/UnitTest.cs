using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using JiraRestClient;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private Uri jiraUri = new Uri("http://localhost:2990/jira");
        private string username = "admin";
        private string password = "admin";

        [TestMethod]
        public void TestMethod1()
        {
            JiraClient restClient = new JiraClient(jiraUri, password, username);
            IssueClient issueclient = restClient.IssueClient;
            issueclient.GetIssueByKey("DEMO-1");
        }
    }
}
