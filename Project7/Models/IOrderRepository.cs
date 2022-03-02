using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// building repository
// set as interface instead of class (template to build the rest of the info for the individual repo)
// if don't specify public, that's still the default

namespace Project7.Models
{
    public interface IOrderRepository
    {
        IQueryable<Order> Checkout { get; }
        public void SaveOrder(Order Checkout);
    }
}
