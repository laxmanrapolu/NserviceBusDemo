using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendToFandI.Contracts.Events
{
    public class DealCompleted
    {
        public Guid QuoteNumber { get; set; }
        public int DealNumber { get; set; }
    }
}
