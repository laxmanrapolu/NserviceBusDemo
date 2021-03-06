﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using SendToFandI.Contracts.Commands;
using SendToFandI.Contracts.Messages;

namespace SendToFandI.Endpoint.Handlers
{
    public class SendToFandIHandler : IHandleMessages<SendToFICommand>
    {
        private IBus Bus;
        public SendToFandIHandler(IBus bus)
        {
            Bus = bus;
        }

        public void Handle(SendToFICommand message)
        {
            #region FaultTolerance

         //   throw new Exception("Custom exception");

            #endregion

            #region HandleMessage

            Console.WriteLine("SendToFandI Endpoint : Send To Fi request received for Quote Id {0}", message.QuoteNumber);
            Console.WriteLine("");

            #endregion

            #region SendPurchaseDeal
            var purchaseDeal = new PurchaseDeal()
            {
                QuoteNumber = message.QuoteNumber,
                CustomerId = message.CustomerId
            };

            Bus.Send(purchaseDeal);

            Console.WriteLine("SendToFandI Endpoint : Updated Standard Terms and sent deal to Dis");
            Console.WriteLine("");

            #endregion
        }
    }
}
