using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventStore.Models;

namespace EventStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        EventStoreDB db = new EventStoreDB();

        // GET: ShoppingCart
        [Authorize]
        public ActionResult Index()
        {
            ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext);

            ShoppingCartViewModel vm = new ShoppingCartViewModel()
            {
                CartItems = cart.GetCartItems(),
            };

            return View(vm);
        }

        // GET: ShoppingCart/AddToCart/7
        [Authorize]
        public ActionResult AddToCart(int id/*, int count*/)
        {
            ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext);
            cart.AddToCart(id);
            return RedirectToAction("Index");
        }

   

        // POST: ShoppingCart/RemoveFromCart/
        [Authorize]
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext);

            Event order = db.Carts.SingleOrDefault(c => c.RecordId == id).EventSelected;

            int newItemCount = cart.RemoveFromCart(id);

            ShoppingCartRemoveViewModel vm = new ShoppingCartRemoveViewModel()
            {
                DeleteId = id,
                //CartTotal = cart.GetCartTotal(),
                ItemCount = newItemCount,
                Message = "One (1) reservation for " + order.EventName + " has been canceled."
            };

            return Json(vm);
        }
    }
}