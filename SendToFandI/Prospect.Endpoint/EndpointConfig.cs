
namespace Prospect.Endpoint
{
    using NServiceBus;

	/*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization, IWantToRunBeforeConfigurationIsFinalized
    {
        public void Init()
        {
            Configure.With()
                 .DefiningEventsAs(t => t.Namespace == "SendToFandI.Contracts.Events" && t.Namespace.EndsWith("Events"))
                 .DefineEndpointName("Prospect.Endpoint");
        }

        public void Run()
        {
            Configure.Instance.UseTransport<NServiceBus.RabbitMQ>(() => "host=localhost");
        }
    }
}
