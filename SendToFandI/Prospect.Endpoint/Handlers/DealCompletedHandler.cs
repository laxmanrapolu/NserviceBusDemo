using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using SendToFandI.Contracts.Events;

namespace Prospect.Endpoint.Handlers
{
    public class DealCompletedHandler : IHandleMessages<DealCompleted>
    {
        public void Handle(DealCompleted message)
        {
            Console.WriteLine("Prospect Endpoint : Received Deal Number : {0}", message.DealNumber);
            Console.WriteLine("");
        }
    }
}
