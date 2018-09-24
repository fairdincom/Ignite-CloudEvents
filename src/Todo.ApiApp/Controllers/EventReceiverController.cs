using System.Threading.Tasks;

using Aliencube.CloudEventsNet;

using Microsoft.AspNetCore.Mvc;

using Todo.Models;

namespace Todo.ApiApp.Controllers
{
    /// <summary>
    /// This represents the controller entity to send back to the console app with the payload structure.
    /// </summary>
    [Route("api/events")]
    public class EventReceiverController : Controller
    {
        /// <summary>
        /// Invoke POST methods.
        /// </summary>
        /// <param name="payload"><see cref="ObjectEvent{ToDo}"/> instance.</param>
        /// <returns>Returns the response.</returns>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> PostAsync([FromBody]ObjectEvent<ToDo> payload)
        {
            var response = new { Headers = this.Request.Headers, Body = payload };

            return await Task.FromResult(new OkObjectResult(response)).ConfigureAwait(false);
        }
    }
}