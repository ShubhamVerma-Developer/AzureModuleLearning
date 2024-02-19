using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.Sql;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SqlTriggerBindingYoutubeGeekFest
{
    public static class TodoApp
    {
        [FunctionName("Create-todos")]
        public static async Task<IActionResult> Create(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "todos")] HttpRequest req,
            ILogger log,
            [Sql("Todo2", connectionStringSetting: "SqlConnection")] IAsyncCollector<Todo> todos
            )
        {
           
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            var items = JsonConvert.DeserializeObject<TodoItems>(body);
            
            foreach(var item in items.Items)
            {
                item.Id = Guid.NewGuid();
                await todos.AddAsync(item);
            }

            await todos.FlushAsync();
            return new OkResult();
        }




        [FunctionName("get-todos")]
        public static IActionResult Get(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "todos/{id:guid?}")] HttpRequest req,
            ILogger log,
            [Sql(@"
                If (@id IS NULL or @id = '')
                    SELECT Id, Title, Completed
                    FROM Todo2
                ELSE
                    SELECT Id, Title, Completed
                    FROM Todo2
                    WHERE Id = @id                
             " ,
            parameters: "@id={id}",
            commandType: System.Data.CommandType.Text,
            connectionStringSetting: "SqlConnection")] IEnumerable<Todo> todos
            )
        {

            return new OkObjectResult(todos);
        }

        [FunctionName("TrackChanges")]
        public static void Run(
            [SqlTrigger("Todo2", connectionStringSetting:"SqlConnection")]
            IReadOnlyList<SqlChange<Todo>> changes,
            ILogger log
            )
        {
            foreach (var change in changes)
            {
                log.LogInformation($"operation {change.Operation}");
                log.LogInformation($"Change: \r\n {System.Text.Json.JsonSerializer.Serialize(change.Item)}");
            }
        }

    }
}
