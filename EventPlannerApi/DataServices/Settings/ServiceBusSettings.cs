namespace EventPlannerApi.DataServices.Settings
{
    public class ServiceBusSettings
    {
        public const string SettingName = "ServiceBusSettings";
        public string connectionString { get; set; }
        public string queueName { get; set; }
    }
}
