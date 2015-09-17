using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using SendToFandI.Contracts.Commands;

namespace Quoting.Api.Controllers
{
    public class SendToFandIController : ApiController
    {
        public Guid Get()
        {
            var sendToFI = new SendToFICommand()
            {
                QuoteNumber = Guid.NewGuid(),
                CustomerId = Guid.NewGuid()
            };

            WebApiApplication.Bus.Send(sendToFI);
            return sendToFI.QuoteNumber;
        }
    }
}