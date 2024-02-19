using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;

namespace Calculator
{
    public static class Function1
    {
        [FunctionName("Sum")]
        public static async Task<IActionResult> Sum(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function for Sum processed a request.");

            int x = int.Parse(req.Query["x"]);
            int y = int.Parse(req.Query["y"]);

            int result = x + y;

            return new OkObjectResult(result);
        }

        [FunctionName("Sub")]
        public static async Task<IActionResult> Sub(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function for Sub processed a request.");

            int x = int.Parse(req.Query["x"]);
            int y = int.Parse(req.Query["y"]);

            int result = x - y;

            return new OkObjectResult(result);
        }
    }
}
