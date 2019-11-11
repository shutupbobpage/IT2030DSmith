using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCMusicStoreApplication.Models
{
    public class Cart
    {
        [Key] //tells Entity that I want RecordId for primarykey; default would search for class name, so it would attempt CartId
        public int RecordId { get; set; } //primarykey
        public string CartId { get; set; }
        public int AlbumId { get; set; } //album to be added to cart
        public virtual Album AlbumSelected { get; set; } //virtualtag - 1) won't add to Album database 2) "lazy loading"
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }

    }
}