
using System;
using System.Collections.Generic;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;


namespace SqlTriggerDemo1
{
    public class ToDoTrigger
    {
        [Function("ToDoTrigger")]
        public static void Run(
            [SqlTrigger("[dbo].[ToDo]", "SqlConnectionString")]
            IReadOnlyList<SqlChange<ToDoItem>> changes,
            FunctionContext context)
        {
            var logger = context.GetLogger("ToDoTrigger");
            foreach (SqlChange<ToDoItem> change in changes)
            {
                ToDoItem toDoItem = change.Item;
                logger.LogInformation($"Change operation: {change.Operation}");
                logger.LogInformation($"Id: {toDoItem.Id}, Name: {toDoItem.Name}, Description: {toDoItem.Description}");
            }
        }
    }

    public class ToDoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
    }
}
