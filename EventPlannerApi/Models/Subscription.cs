using Newtonsoft.Json;
using System;

namespace EventPlannerApi.Models
{
    public class Subscription
    {
        [JsonProperty("id")]
        public string subscriptionId { get; set; }
        public string eventPlanId { get; set; }
        public string clientId { get; set; }
        public DateTime subscribedDateTime { get; set; }        
        public string subscriptionStatus { get; set; }
        public Subscriber subscriber { get; set; }

    }
}
