using System;
using System.Net.Http;
using System.Threading.Tasks;

using Aliencube.CloudEventsNet;
using Aliencube.CloudEventsNet.Http;

using Newtonsoft.Json.Linq;

using Todo.Models;

namespace CloudEvents.ConsoleApp
{
    /// <summary>
    /// This represents the console app entity that shows CloudEvent data payload.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Invokes the console app.
        /// </summary>
        /// <param name="args">List of arguments.</param>
        public static void Main(string[] args)
        {
            var todo = new ToDo() { Title = "sample todo" };
            var contentType = "application/json";

            var ce = CloudEventFactory.Create(contentType, todo);
            ce.EventType = "com.fairdin.ToDoApp.Todos.OnTodoCreated";
            ce.EventTypeVersion = "1.0";
            ce.Source = "https://fairdin.com/apps/todo";
            ce.EventId = Guid.NewGuid().ToString();
            ce.EventTime = DateTimeOffset.UtcNow;
            ce.Extensions = new { correlationId = Guid.NewGuid().ToString() };

            var requestUri = "https://localhost:44328/api/events";

            using (var client = new HttpClient())
            using (var content = CloudEventContentFactory.Create(ce))
            {
                var body = GetResponseAsync(client, requestUri, content).Result;

                Console.WriteLine(body);
            }
        }

        private static async Task<string> GetResponseAsync(HttpClient client, string requestUri, HttpContent content)
        {
            using (var response = await client.PostAsync(requestUri, content).ConfigureAwait(false))
            {
                var body = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                return JToken.Parse(body).ToString();
            }
        }
    }
}