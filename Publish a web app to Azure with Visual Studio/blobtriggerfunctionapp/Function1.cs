using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace blobtriggerfunctionapp
{
    public class Function1
    {
        [FunctionName("Function1")]
        public void Run([BlobTrigger("samples-workitems/{name}", Connection = "connectionString")]Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}
