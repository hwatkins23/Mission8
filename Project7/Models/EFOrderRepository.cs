using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project7.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private BookstoreContext context;
        public EFOrderRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Order> Checkout => context.Checkout.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveOrder(Order Checkout)
        {
            context.AttachRange(Checkout.Lines.Select(x => x.Book));
            if (Checkout.CheckoutId == 0)
            {
                context.Checkout.Add(Checkout);
            }

            context.SaveChanges();
        }
    }
}
