using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Octokit;

namespace GitHub.ConsoleApp
{
    /// <summary>
    /// This represents the console app entity that calls GitHub issue/comment API.
    /// </summary>
    public static class Program
    {
        private const string ProductName = "IgniteCloudEventsDemo";
        private const string Username = "[GITHUB_USERNAME]";
        private const string Password = "[GITHUB_PASSWORD]";
        private const string RepositoryId = "[GITHUB_REPOSITORY_ID_IN_NUMBER]";
        private const string IssueNumber = "[GITHUB_ISSUE_NUMBER]";

        /// <summary>
        /// Invokes the console app.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var range = Enumerable.Range(0, 100).Select(i => i).ToList();
            foreach (var i in range)
            {
                var comment = $"Hello Ignite #{i.ToString("00")}";

                var client = new GitHubClient(new ProductHeaderValue(ProductName))
                                 {
                                     Credentials = new Credentials(Username, Password)
                                 };
                var body = GetResponseAsync(client, comment).GetAwaiter().GetResult();

                Console.WriteLine(comment);

                Thread.Sleep(2000);
            }
        }

        private static async Task<string> GetResponseAsync(GitHubClient client, string comment)
        {
            var result = await client.Issue.Comment.Create(Convert.ToInt64(RepositoryId), Convert.ToInt32(IssueNumber), comment).ConfigureAwait(false);

            return result.Body;
        }
    }
}