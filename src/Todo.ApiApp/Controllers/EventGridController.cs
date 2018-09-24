using System;
using System.Net.Http;
using System.Threading.Tasks;

using Aliencube.CloudEventsNet;
using Aliencube.CloudEventsNet.Http;

using Microsoft.AspNetCore.Mvc;

using Todo.Models;

namespace Todo.ApiApp.Controllers
{
    [Route("api/eventgrid")]
    public class EventGridController : Controller
    {
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> PostAsync([FromBody]ToDo payload)
        {
            var contentType = "application/json";

            var ce = CloudEventFactory.Create(contentType, payload);
            ce.EventType = "com.fairdin.ToDoApp.Todos.OnTodoCreated";
            ce.EventTypeVersion = "1.0";
            ce.Source = "/subscriptions/[SUBSCRIPTION_ID]/resourceGroups/[RESOURCE_GROUP_NAME]/providers/microsoft.eventgrid/topics/[EVENT_GRID_TOPIC_NAME]#OnTodoCreated";

            ce.Extensions = new { origin = "Todo App" };

            ce.EventId = Guid.NewGuid().ToString();
            ce.EventTime = DateTimeOffset.UtcNow;
            ce.ContentType = "application/json";

            var requestUri = "[CUSTOM_EVENT_GRID_TOPIC_ENDPOINT]";

            using (var client = new HttpClient())
            using (var content = CloudEventContentFactory.Create(ce))
            {
                content.Headers.Add("AEG-SAS-KEY", "[CUSTOM_EVENT_GRID_TOPIC_ACCESS_KEY]");

                var response = await client.PostAsync(requestUri, content).ConfigureAwait(false);

                return new OkObjectResult(response.ReasonPhrase);
            }
        }
    }
}