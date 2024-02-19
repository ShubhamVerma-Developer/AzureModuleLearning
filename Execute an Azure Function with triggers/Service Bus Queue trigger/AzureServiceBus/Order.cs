using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AzureServiceBusQueue
{
    public class Order
    {
        public string OrderID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
