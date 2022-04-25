namespace EventPlannerApi.DataServices.Settings
{

    public class CosmosSettings
    {
        public const string SettingName = "CosmosSettings";
        public string endPoint { get; set; }
        public string key { get; set; }
        public string databaseName { get; set; }

    }

}
