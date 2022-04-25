using Azure.Messaging.ServiceBus;

namespace EventPlannerApi.DataServices
{
    public interface IServiceBusContext
    {
        ServiceBusSender sender { get; }
        ServiceBusClient client { get; }
        void Dispose();
    }
}
