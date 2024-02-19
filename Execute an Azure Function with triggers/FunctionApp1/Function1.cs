using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Extensions.Storage;
using System.Net.Http;

namespace FunctionApp1
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string apiUrl = "https://api-02019486440.crtx.us.paloaltonetworks.com/xsoar/public/v1/incidents/search"; 

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return new OkObjectResult(responseBody);
                }
                else
                {
                    log.LogError($"Failed to call the API. Status Code: {response.StatusCode}");
                    return new StatusCodeResult((int)response.StatusCode);
                }
            }
        }
    }
}
