using Azure.Messaging.ServiceBus;
using System;
using System.Runtime.CompilerServices;

namespace AzureServiceBusQueue
{
    class Program
    {
        private static string connection_string = "Endpoint=sb://appnamespace1000.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=2F5HlXRnzA+Ohp/3NdC+qa1Xy/Brnhu9i+ASbOL2b+8=";
        private static string queue_name = "appqueue";
        static void Main(string[] args)
        {
            SendMessage();
            //GetPeekMessages();
            //DeletePeekMessages();

            Console.ReadKey();
        }


        public static void SendMessage()
        {
            List<Order> _orders = new List<Order>()
            {
                new Order() {OrderID="01", Quantity=10, UnitPrice=4.99m},
                new Order() {OrderID="02", Quantity=15, UnitPrice=8.99m},
                new Order() {OrderID="03", Quantity=16, UnitPrice=4.99m},
                new Order() {OrderID="04", Quantity=18, UnitPrice=9.99m},
                new Order() {OrderID="05", Quantity=19, UnitPrice=4.99m},
                new Order() {OrderID="06", Quantity=18, UnitPrice=7.99m},
            };
            ServiceBusClient _client = new ServiceBusClient(connection_string);
            ServiceBusSender _sender = _client.CreateSender(queue_name);

            foreach (Order _order in _orders)
            {
                ServiceBusMessage _message = new ServiceBusMessage(_order.ToString());
                _message.ContentType = "application/json";
                _sender.SendMessageAsync(_message).GetAwaiter().GetResult();
            }
            Console.WriteLine("All of the message have been sent");
        }

        public static void GetPeekMessages()
        {
            ServiceBusClient _client = new ServiceBusClient(connection_string);
            ServiceBusReceiver _reciever = _client.CreateReceiver(queue_name, new ServiceBusReceiverOptions() {  ReceiveMode = ServiceBusReceiveMode.PeekLock });

            ServiceBusReceivedMessage _message = _reciever.ReceiveMessageAsync().GetAwaiter().GetResult();
            Console.WriteLine(_message.Body.ToString());
            Console.ReadKey();
        }

        public static void DeletePeekMessages()
        {
            ServiceBusClient _client = new ServiceBusClient(connection_string);
            ServiceBusReceiver _reciever = _client.CreateReceiver(queue_name, new ServiceBusReceiverOptions() { ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete });

            var _messages = _reciever.ReceiveMessagesAsync(1).GetAwaiter().GetResult();


            foreach(var _message in _messages)
            {
                Console.WriteLine(_message.SequenceNumber);
                Console.WriteLine(_message.Body.ToString());
            }

            Console.ReadKey();
        }


    }
}