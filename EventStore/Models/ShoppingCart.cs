﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventStore.Models
{
    public class ShoppingCart
    {
        public string ShoppingCartId;
        private EventStoreDB db = new EventStoreDB();

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            ShoppingCart cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        private string GetCartId(HttpContextBase context)
        {
            const string CartSessionId = "CartId";
            string cartId;

            if (context.Session[CartSessionId] == null)
            {
                // Create a new cart id
                cartId = Guid.NewGuid().ToString();
                // Save to the session date
                context.Session[CartSessionId] = cartId;
            }
            else
            {
                // Return the existing cart id
                cartId = context.Session[CartSessionId].ToString();
            }

            return cartId;
        }

        public List<Cart> GetCartItems()
        {
            return db.Carts.Where(c => c.CartId == this.ShoppingCartId).ToList();
        }

        public void AddToCart(int eventId)
        {
            //TODO: Verify that the Album Id exists in the database.
            Cart cartItem = db.Carts.SingleOrDefault(c => c.CartId == this.ShoppingCartId && c.EventId == eventId);

            // Item is not in cart, add new cart item
            if (cartItem == null)
            {
                cartItem = new Cart()
                {
                    CartId = this.ShoppingCartId,
                    EventId = eventId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                db.Carts.Add(cartItem);
            }
            // Item is in cart, just need to increase item count
            else
            {
                //increase by 1
                cartItem.Count++;
            }
            db.SaveChanges();
        }

        public int RemoveFromCart(int eventId)
        {
            Cart cartItem = db.Carts.SingleOrDefault(c => c.CartId == this.ShoppingCartId && c.RecordId == eventId);
            if (cartItem == null)
            {
                throw new NullReferenceException();
            }

            int newCount;
            // Item is in the cart and the count is greater than 1; decrement count
            if (cartItem.Count > 1)
            {
                cartItem.Count--;
                newCount = cartItem.Count;
            }
            // Item is =< 1, remove item completely
            else
            {
                db.Carts.Remove(cartItem);
                newCount = 0;
            }

            db.SaveChanges();

            return newCount;
        }
    }
}