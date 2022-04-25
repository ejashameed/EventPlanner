using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace EventPlannerApi.Models
{
    public class EventPlan
    {

        [JsonProperty("clientId")]
        public string? ClientId { get; set; }

        [JsonProperty("id")]
        public string? EventPlanId { get; set; }
        
        public string? EventName { get; set; }

        public string? EventDescription { get; set; }

        [DisplayFormat(DataFormatString = "{dd MMM yyyy hh:mm tt} ")]
        public DateTime EventStartDate { get; set; }

        [DisplayFormat(DataFormatString = "{dd MMM yyyy hh:mm tt} ")]
        public DateTime EventEndDate { get; set; }
        public bool IsEventCompleted { get; set; }
    }
}
