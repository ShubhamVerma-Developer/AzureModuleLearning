using Azure.Messaging.ServiceBus;
using System;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string connectionString = "Endpoint=sb://appnamespace1000.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=2F5HlXRnzA+Ohp/3NdC+qa1Xy/Brnhu9i+ASbOL2b+8=";
        string topicName = "messagetopiccreated";

        await using ServiceBusSender sender = new ServiceBusClient(connectionString).CreateSender(topicName);

        ServiceBusMessage message = new ServiceBusMessage(Encoding.UTF8.GetBytes("Hello This is Message for testing the service bus topic"));

        await sender.SendMessageAsync(message);

        Console.WriteLine("Message sent to Service Bus Topic.");
    }
}
