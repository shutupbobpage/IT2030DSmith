using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EventStore.Models
{
    public class SampleData : DropCreateDatabaseAlways<EventStoreDB>
    {
        protected override void Seed(EventStoreDB context)
        {

            var types = new List<EventType>
            {
                new EventType {TypeName = "Concert"},
                new EventType {TypeName = "Auto Show"},
                new EventType {TypeName = "Tech Conference"},
                new EventType {TypeName = "Sporting Event"},
                new EventType {TypeName = "Some guy yelling for an hour"},
                new EventType {TypeName = "Fast Food Cooking Competition"},
                new EventType {TypeName = "Andy Kaufmann Impersonator Convention"},
                new EventType {TypeName = "E-Sports Event"},
                new EventType {TypeName = "Tax Loophole Seminar"},
                new EventType {TypeName = "Arts"}
            };

            new List<Event>
            {
                new Event {EventType = types.Single(g => g.TypeName == "Concert"),
                           OrganizerName = "Mahnob",
                           EventName = "Del Nileppez",
                           EventDescription = "A cover band",
                           EventStart = new DateTime(2019, 12, 16, 20, 30, 0),
                           EventEnd = new DateTime(2019, 12, 16, 22, 30, 0),                      
                           Location = "Akron, OH",
                           MaxTickets = 1000,
                           AvailableTickets = 1000},
                new Event {EventType = types.Single(g => g.TypeName == "Auto Show"),
                           OrganizerName = "Great Motorcars",
                           EventName = "Awesome Car Show 2019",
                           EventDescription = "See new cars!",
                           EventStart = new DateTime(2019, 12, 17, 8, 30, 0),
                           EventEnd = new DateTime(2019, 12, 17, 18, 30, 0),
                           Location = "Akron, OH",
                           MaxTickets = 1000,
                           AvailableTickets = 1000},
                new Event {EventType = types.Single(g => g.TypeName == "Tech Conference"),
                           OrganizerName = "Tech Cleveland",
                           EventName = "Cleveland Tech",
                           EventDescription = "Technology",
                           EventStart = new DateTime(2019, 12, 16, 10, 30, 0),
                           EventEnd = new DateTime(2019, 12, 16, 11, 30, 0),
                           Location = "Cleveland, OH",
                           MaxTickets = 1000,
                           AvailableTickets = 1000},
                new Event {EventType = types.Single(g => g.TypeName == "Sporting Event"),
                           OrganizerName = "John Sports",
                           EventName = "Midwest Curling Championship",
                           EventDescription = "No flash photography",
                           EventStart = new DateTime(2020, 12, 20, 10, 30, 0),
                           EventEnd = new DateTime(2020, 12, 20, 12, 30, 0),
                           Location = "Akron, OH",
                           MaxTickets = 1000,
                           AvailableTickets = 1000},
                new Event {EventType = types.Single(g => g.TypeName == "Some guy yelling for an hour"),
                           OrganizerName = "Jello Biafra",
                           EventName = "Spoken Word Album",
                           EventDescription = "not Dead Kennedys",
                           EventStart = new DateTime(2021, 4, 1, 10, 30, 0),
                           EventEnd = new DateTime(2021, 4, 3, 10, 30, 0),
                           Location = "Green, OH",
                           MaxTickets = 1000,
                           AvailableTickets = 1000},
                new Event {EventType = types.Single(g => g.TypeName == "Fast Food Cooking Competition"),
                           OrganizerName = "ISO",
                           EventName = "Food Safety Championship",
                           EventDescription = "Who can cook the most fast food and make the least amount of people sick?",
                           EventStart = new DateTime(2020, 6, 1, 10, 30, 0),
                           EventEnd = new DateTime(2020, 7, 1, 10, 30, 0),
                           Location = "Barberton, OH",
                           MaxTickets = 1000,
                           AvailableTickets = 1000},
                new Event {EventType = types.Single(g => g.TypeName == "Andy Kaufmann Impersonator Convention"),
                           OrganizerName = "'Andy Kaufmann'",
                           EventName = "Andy Kaufmann 2020",
                           EventDescription = "Taxi Fanclub",
                           EventStart = new DateTime(2020, 5, 6, 10, 30, 0),
                           EventEnd = new DateTime(2020, 5, 6, 12, 30, 0),
                           Location = "Wadsworth, OH",
                           MaxTickets = 1000,
                           AvailableTickets = 1000},
                new Event {EventType = types.Single(g => g.TypeName == "E-Sports Event"),
                           OrganizerName = "Goose",
                           EventName = "Untitled Goose Game Competition",
                           EventDescription = "honk",
                           EventStart = new DateTime(2019, 12, 17, 10, 30, 0),
                           EventEnd = new DateTime(2019, 12, 17, 11, 30, 0),
                           Location = "Akron, OH",
                           MaxTickets = 1000,
                           AvailableTickets = 1000},
                new Event {EventType = types.Single(g => g.TypeName == "Tax Loophole Seminar"),
                           OrganizerName = "Anonymous",
                           EventName = "Stop Paying Taxes? A How-To Event",
                           EventDescription = "Tax Assistance",
                           EventStart = new DateTime(2020, 3, 1, 10, 30, 0),
                           EventEnd = new DateTime(2020, 3, 1, 12, 30, 0),
                           Location = "Hudson, OH",
                           MaxTickets = 1000,
                           AvailableTickets = 1000},
                new Event {EventType = types.Single(g => g.TypeName == "Arts"),
                           OrganizerName = "Arthur Figgis",
                           EventName = "A Tribute to Composers",
                           EventDescription = "Baroque",
                           EventStart = new DateTime(2019, 12, 16, 18, 30, 0),
                           EventEnd = new DateTime(2019, 12, 16, 22, 30, 0),
                           Location = "Parma, OH",
                           MaxTickets = 1000,
                           AvailableTickets = 1000},                
            }.ForEach(a => context.Events.Add(a));
        }
    }
}