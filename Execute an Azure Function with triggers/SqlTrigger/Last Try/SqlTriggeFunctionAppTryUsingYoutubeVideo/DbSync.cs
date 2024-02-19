using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Sql;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SqlTriggeFunctionAppTryUsingYoutubeVideo
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
    public static class DbSync
    {
        [FunctionName("DbSync")]
        public static void Run(
            [SqlTrigger("Todo2", connectionStringSetting:"Db")]
            IReadOnlyList<SqlChange<Todo>> changes,
            ILogger log 
            )
        {
            foreach(var change in changes )
            {
                log.LogInformation($"operation {change.Operation}");
                log.LogInformation($"Change: \r\n {JsonSerializer.Serialize(change.Item)}");
            }
        }
    }
}
