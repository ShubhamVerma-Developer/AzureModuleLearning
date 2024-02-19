using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHubWithCosmos
{
    public class Details
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }

    public class DetailsItems
    {
        public Details[] Items { get; set; }
    }
}
