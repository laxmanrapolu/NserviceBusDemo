using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using SendToFandI.Contracts.Commands;

namespace SendToFandI.Endpoint.Handlers
{
    public class AuthenticationHandler : IHandleMessages<SendToFICommand>
    {
        private IBus Bus;
        public AuthenticationHandler(IBus bus)
        {
            Bus = bus;
        }
        public void Handle(SendToFICommand message)
        {
            var accessToken = Bus.GetMessageHeader(message, "Access-Token");
            if (accessToken == "quoting")
            {
                Console.WriteLine("Authentication failed");
                Console.WriteLine("");
                Bus.DoNotContinueDispatchingCurrentMessageToHandlers();
                return;
            }
            Console.WriteLine("");
           // Console.WriteLine("User Authenticated");
            Console.WriteLine("");
        }
    }
}
