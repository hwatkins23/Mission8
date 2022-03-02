using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Project7.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Project7.Models
{
    // sets up inheritence from the basket class
    public class SessionBasket : Basket
    {

        public static Basket GetBasket (IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            // check to see if the basket exists and if it does then use it, if not create a new basket and add to that
            SessionBasket basket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();
            // if the session has an entry for the current session, if there's not then create a new session basket 
            
            basket.Session = session;

            return basket;
        }
        
        [JsonIgnore]
        public ISession Session { get; set; }
        // ISession it's a unique identifier for a session but it's not a session cookie

        public override void AddItem(Book Book, int qty)
        {
            base.AddItem(Book, qty);
            // set json file based on new basket
            Session.SetJson("Basket", this);
            // 'this' refers to the current instance of the class
        }

        public override void RemoveItem(Book Book)
        {
            base.RemoveItem(Book);
            Session.SetJson("Basket", this);
        }

        public override void ClearBasket()
        {
            base.ClearBasket();
            Session.SetJson("Basket", this);
        }
    }
}
