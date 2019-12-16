using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EventStore.Models
{
    public class EventType
    {
        [Key]
        public virtual int TypeId { get; set; }

        [DisplayName("Event Type")]
        public virtual string TypeName { get; set; }
        
    }
}