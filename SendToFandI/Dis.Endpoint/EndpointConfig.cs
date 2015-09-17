
namespace Dis.Endpoint
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
                .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.EndsWith("Commands"))
                .DefiningMessagesAs(t => t.Namespace == "SendToFandI.Contracts.Messages")
                .DefineEndpointName("Dis.Endpoint");
        }

        public void Run()
        {
            Configure.Instance.UseTransport<NServiceBus.RabbitMQ>(() => "host=localhost");
        }
    }
}
