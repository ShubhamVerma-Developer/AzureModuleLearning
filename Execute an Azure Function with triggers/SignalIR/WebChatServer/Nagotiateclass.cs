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

namespace WebChatServer
{
    public static class NegotiateClass
    {
        [FunctionName("Negotiate")]
        public static SignalRConnectionInfo Negotiate(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [SignalRConnectionInfo(HubName = "MyChatRoom")] SignalRConnectionInfo connectionInfo,
            ILogger log)
        {
            return connectionInfo;
        }
    }
}
