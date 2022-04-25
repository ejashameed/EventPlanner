using Azure.Messaging.ServiceBus;
using EventPlannerApi.DataServices.Settings;

namespace EventPlannerApi.DataServices
{
    public class ServiceBusContext : IServiceBusContext
    {
        public ServiceBusSender sender { get; }
        public ServiceBusClient client { get; }

        private readonly ServiceBusSettings _serviceBusSettings;

        public ServiceBusContext(ServiceBusSettings serviceBusSettings)
        {
            _serviceBusSettings = serviceBusSettings;

            client = new ServiceBusClient(_serviceBusSettings.connectionString);            
            sender = client.CreateSender(_serviceBusSettings.queueName);

        }
       
        public async void Dispose()
        {
            await sender.DisposeAsync();
            await client.DisposeAsync();
        }
    }
}
