using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EventStore.Models
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; } //primarykey
        public string CartId { get; set; }
        public int EventId { get; set; } //event to be added to cart
        public virtual Event EventSelected { get; set; } //virtualtag - 1) won't add to Album database 2) "lazy loading"
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }
    }
}