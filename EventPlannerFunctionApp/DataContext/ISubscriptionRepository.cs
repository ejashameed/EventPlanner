using EventPlannerFunctionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerFunctionApp.DataContext
{
    public interface ISubscriptionRepository
    {
        Task<Subscription> CreateSubscription(Subscription subscription);
    }
}
