using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendToFandI.Contracts.Messages
{
    public class PurchaseDeal
    {
        public Guid QuoteNumber { get; set; }
        public Guid CustomerId { get; set; }
    }
}
