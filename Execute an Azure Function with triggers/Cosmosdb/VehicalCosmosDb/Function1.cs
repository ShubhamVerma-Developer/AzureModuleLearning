using System;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace VehicalCosmosDb
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([CosmosDBTrigger(
            databaseName: "DemoCosmos",
            collectionName: "Vehical",
            ConnectionStringSetting = "CosmosDBConnectionString",
            CreateLeaseCollectionIfNotExists = true,
            LeaseCollectionName = "leases")]IReadOnlyList<Document> input,
            ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                var vehicalNo = input[0].GetPropertyValue<string>("vehicalNumber");
                var speed = input[0].GetPropertyValue<double>("speed");
                var city = input[0].GetPropertyValue<string>("city");
                var mobile = input[0].GetPropertyValue<string>("mobile");

                if (speed > 80)
                {
                    var message = $"High Speed detected {city}, vehical no {vehicalNo}, speed{speed}";
                    log.LogInformation(message);
                }
                else
                {
                    var message = $"Low Speed detected {city}, vehical no {vehicalNo}, speed{speed}";
                    log.LogInformation(message);
                }
            }
        }
    }
}
