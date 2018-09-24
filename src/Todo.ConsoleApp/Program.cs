using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Todo.Models;

namespace Todo.ConsoleApp
{
    /// <summary>
    /// This represents the console app entity that calls Web API.
    /// </summary>
    public static class Program
    {
        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Invokes the console app.
        /// </summary>
        /// <param name="args">List of arguments.</param>
        public static void Main(string[] args)
        {
            var requestUri = "https://localhost:44328/api/eventgrid";

            var range = Enumerable.Range(0, 100).Select(i => i).ToList();
            foreach (var i in range)
            {
                var title = $"Hello Ignite #{i.ToString("00")}";
                var todo = new ToDo() { Title = title };

                using (var content = new StringContent(JsonConvert.SerializeObject(todo), Encoding.UTF8, "application/json"))
                {
                    var body = GetResponseAsync(requestUri, content).GetAwaiter().GetResult();
                }

                Console.WriteLine(title);

                Thread.Sleep(2000);
            }
        }

        private static async Task<string> GetResponseAsync(string requestUri, HttpContent content)
        {
            using (var response = await client.PostAsync(requestUri, content).ConfigureAwait(false))
            {
                var body = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                return body;
            }
        }
    }
}