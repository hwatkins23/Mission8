using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project7.Models
{
    public class EFCheckoutRepository : ICheckoutRepository
    {
        private BookstoreContext context;
        public EFCheckoutRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Checkout> Checkout => context.Checkout.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveOrder(Checkout Checkout)
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
