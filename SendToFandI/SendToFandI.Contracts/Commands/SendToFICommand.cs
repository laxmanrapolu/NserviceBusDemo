﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendToFandI.Contracts.Commands
{
    public class SendToFICommand
    {
        public Guid QuoteNumber { get; set; }
        public Guid CustomerId { get; set; }
    }
}
