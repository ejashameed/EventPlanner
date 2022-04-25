using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerFunctionApp.Models
{
    public class Subscription
    {
        public string subscriptionId { get; set; }
        public string eventPlanId { get; set; }
        public string clientId { get; set; }
        public DateTime subscribedDateTime { get; set; }
        public string subscriptionStatus { get; set; }
        public Subscriber subscriber { get; set; }
    }
}
