using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EventHubWithCosmos
{
    public static class EventHubWithCosmos
    {
        [FunctionName("EventHubTrigger")]
        public static async Task Run([CosmosDBTrigger(
            databaseName: "DemoCosmos",
            collectionName: "EventHubDemo",
            ConnectionStringSetting = "CosmosDBConnectionString",
            CreateLeaseCollectionIfNotExists = true,
            LeaseCollectionName = "leases")]IReadOnlyList<Document> input,
            [EventHub("cosmosdata", Connection ="EventHubConnectionstring")] IAsyncCollector<string> outputEvents,
            ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                log.LogInformation("Documents modified " + input.Count + " " + DateTime.Now);
                log.LogInformation("First document Id " + input[0].Id);

                foreach (var item in input)
                {
                    await outputEvents.AddAsync(JsonConvert.SerializeObject(item));
                }
            }
        }


      
        [FunctionName("ProcessEvent")]
        public static void ProcessEvent(
        [EventHubTrigger("cosmosdata", Connection = "EventHubConnectionstring")] string message,
        ILogger log)
        {
            log.LogInformation($"C# Event Hub trigger function processed a message: {message}");
        }





        [FunctionName("Add-To-CosmosDB")]
        public static async Task<IActionResult> Create(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "AddCosmos")] HttpRequest req,
            [CosmosDB(
            databaseName: "DemoCosmos",
            collectionName: "EventHubDemo",
            ConnectionStringSetting = "CosmosDBConnectionString")] IAsyncCollector<Details> details,
            ILogger log
            )
        {
                var body = await new StreamReader(req.Body).ReadToEndAsync();
                var items = JsonConvert.DeserializeObject<DetailsItems>(body);

                foreach (var item in items.Items)
                {
                    item.Id = Guid.NewGuid();
                    await details.AddAsync(item);
                }

                await details.FlushAsync();
            return new OkResult();
        }




        [FunctionName("Get-From-CosmosDB")]
        public static IActionResult Read(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetCosmos")] HttpRequest req,
        [CosmosDB(
            databaseName: "DemoCosmos",
            collectionName: "EventHubDemo",
            ConnectionStringSetting = "CosmosDBConnectionString", SqlQuery = "SELECT * FROM c")] IEnumerable<Details> items,
        ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            return new OkObjectResult(items);
        }
    }
}
