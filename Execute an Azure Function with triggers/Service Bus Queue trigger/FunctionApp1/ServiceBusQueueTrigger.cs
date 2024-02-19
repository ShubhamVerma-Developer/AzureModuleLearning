using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Newtonsoft.Json;
using System.IO;

namespace FunctionApp1
{
    public class ServiceBusQueueTrigger
    {
        [FunctionName("ServiceBusQueueTrigger")]
        public void Run([ServiceBusTrigger("appqueue", Connection = "ConnectionString")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }

    }
}


