using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Servicebustopictriggerfunctionapp
{
    public class ServiceBusTopicTrigger
    {
        private readonly ILogger<ServiceBusTopicTrigger> _logger;

        public ServiceBusTopicTrigger(ILogger<ServiceBusTopicTrigger> log)
        {
            _logger = log;
        }

        [FunctionName("ServiceBusTopicTrigger")]
        public void Run([ServiceBusTrigger("messagetopiccreated", "servicebustopictriggersubscription", Connection = "ConnectionString")]string mySbMsg)
        {
            _logger.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
        }
    }
}
