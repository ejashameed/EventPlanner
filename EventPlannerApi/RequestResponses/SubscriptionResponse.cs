using System;

namespace EventPlannerApi.RequestResponses
{
    public class SubscriptionResponse
    {        
        public string subscriptionId { get; set; }
        public string eventPlanId { get; set; }
        public string clientId { get; set; }
        public DateTime subscribedDateTime { get; set; }
        public string subscriptionStatus { get; set; }
        public SubscriberResponse? subscriber { get; set; }
    }
}
