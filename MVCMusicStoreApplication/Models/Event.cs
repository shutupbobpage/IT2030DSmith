using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventStore.Models
{
    public class Event
    {
        public virtual int EventId { get; set; }
        public virtual int GenreId { get; set; }
        public virtual int ArtistId { get; set; }
        public virtual string Title { get; set; }
        public virtual decimal Price { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual string AlbumArtUrl {get; set;}
        public virtual string CountryOfOrigin { get; set; }
        public virtual bool InStock { get; set; }

    }
}