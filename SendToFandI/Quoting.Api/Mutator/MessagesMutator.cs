using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NServiceBus;
using NServiceBus.MessageMutator;

namespace Quoting.Api.Mutator
{
    public class MessagesMutator : IMutateOutgoingTransportMessages, INeedInitialization
    {
        public void MutateOutgoing(object[] messages, TransportMessage transportMessage)
        {
            Headers.SetMessageHeader(transportMessage, "Access-Token", "quoting");
        }

        public void Init()
        {
            Configure.Instance.Configurer.ConfigureComponent<MessagesMutator>(DependencyLifecycle.InstancePerCall);
        }
    }
}