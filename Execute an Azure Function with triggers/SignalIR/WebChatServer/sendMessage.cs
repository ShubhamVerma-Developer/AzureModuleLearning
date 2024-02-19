using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.AspNetCore.SignalR;

namespace WebChatServer
{
    public static class sendMessage
    {
        [FunctionName("sendMessage")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "sendMessage")] HttpRequest req,
            [SignalR(HubName = "MyChatRoom")] IAsyncCollector<SignalRMessage> signalMessages,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var receivedContent = await new StreamReader(req.Body).ReadToEndAsync();
            Message m = JsonConvert.DeserializeObject<Message>(receivedContent);
            await signalMessages.AddAsync(
                new SignalRMessage
                {
                    Target = "newMessage",
                    Arguments = new[] { m }
                });
            
            return new OkResult();
        }
    }

    public class Message
    {
        public string text {  get; set; }
    }
}

