﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using SendToFandI.Contracts.Events;
using SendToFandI.Contracts.Messages;

namespace SendToFandI.Endpoint.Handlers
{
    public class DealCreatedHandler : IHandleMessages<DealCreated>
    {
        private IBus Bus;
        public DealCreatedHandler(IBus bus)
        {
            Bus = bus;
        }
        public void Handle(DealCreated message)
        {
            
            Console.WriteLine("SendToFandI Endpoint : Received Deal from DMS and Deal Number is: {0}", message.DealNumber);
            Console.WriteLine("");


            var dealCompleted = new DealCompleted()
            {
                QuoteNumber = message.QuoteNumber,
                DealNumber = message.DealNumber
            };

            Bus.Publish(dealCompleted);
            Console.WriteLine("SendToFandI Endpoint : Published a Deal completed event: {0}", message.DealNumber);
        }
    }
}