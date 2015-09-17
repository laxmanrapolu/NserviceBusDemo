using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using SendToFandI.Contracts.Messages;

namespace Dis.Endpoint.Handlers
{
    public class PurchaseDealHandler : IHandleMessages<PurchaseDeal>
    {
        private IBus Bus;
        public PurchaseDealHandler(IBus bus)
        {
            Bus = bus;
        }
        public void Handle(PurchaseDeal message)
        {
           Console.WriteLine("Dis Endpoint:  Deal received for QuoteId : {0}", message.QuoteNumber);
           Console.WriteLine("");

            var rnd = new Random();
            var dealNumber = rnd.Next(1000, 1300);

            var dealCreated = new DealCreated()
            {
                QuoteNumber = message.QuoteNumber,
                CustomerId = message.CustomerId,
                DealNumber = dealNumber
            };

            Bus.Reply(dealCreated);
            Console.WriteLine(Bus.CurrentMessageContext.ReplyToAddress);
            Console.WriteLine("");
            Console.WriteLine("Dis Endpoint:  Deal has been processed and sent back deal number : {0}", dealCreated.DealNumber);
            Console.WriteLine("");
        }
    }
}
