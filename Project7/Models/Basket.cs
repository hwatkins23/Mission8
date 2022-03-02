using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project7.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        // virtual allows the method to be overriden when you inherit from it
        public virtual void AddItem (Book Book, int qty)
        {
            BasketLineItem line = Items
                .Where(b => b.Book.BookId == Book.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem {
                    Book = Book,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveItem (Book Book)
        {
            Items.RemoveAll(x => x.Book.BookId == Book.BookId);
        }

        public virtual void ClearBasket ()
        {
            // this will get rid of everything in the cart
            Items.Clear();
        }

        public double CalculateTotal()
        {
            // calculates the total in the cart
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);
            return sum;
        }
    }

    public class BasketLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
