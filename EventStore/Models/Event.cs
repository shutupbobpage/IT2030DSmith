using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EventStore.Models
{
    public class Event
    {
        public virtual int EventId { get; set; } //individual event ID
        public virtual int TypeId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Exceeded maximum character length. (50)")]
        [DisplayName("Event Name")]
        public virtual string EventName { get; set; }

        [StringLength(150, ErrorMessage = "Exceeded maximum character length. (150)")]
        [DisplayName("Event Description")]
        public virtual string EventDescription { get; set; }

        [Required]
        [DisplayName("Event Type")]
        public virtual EventType EventType { get; set; }

        [Required]
        [DateTimeRangeAttribute]
        [DisplayName("Event Start")]
        [DataType(DataType.DateTime)]
        public virtual DateTime EventStart { get; set; }

        [Required]
        [DateTimeRangeAttribute]
        [DisplayName("Event End")]
        [DataType(DataType.DateTime)]
        public virtual DateTime EventEnd { get; set; }

        [Required]
        [Range(typeof(int), "1", "1000", ErrorMessage = "Invalid number of tickets.")]
        [DisplayName("Total Tickets")]
        public virtual int MaxTickets { get; set; }

        [Required]
        [DisplayName("Available Tickets")]
        public virtual int AvailableTickets { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Exceeded maximum character length. (50)")]
        [DisplayName("Organizer Name")]
        public virtual string OrganizerName { get; set; }

        [Required]
        public virtual string Location { get; set; }

    }
}