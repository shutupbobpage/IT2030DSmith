using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventStore.Models
{
    public class ShoppingCartRemoveViewModel
    {
        public int DeleteId;

        public int ItemCount;

        public string Message;
    }
}