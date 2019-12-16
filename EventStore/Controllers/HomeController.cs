using EventStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;

namespace EventStore.Controllers
{
    public class HomeController : Controller
    {
        private EventStoreDB db = new EventStoreDB();

        public ActionResult EventSearch(string q, string p)
        {
            if (q != "" && p == "")
            { 

            var events = GetEvents(q);

            if (events.Any())
            {
                return PartialView("_EventSearch", events);
            }

            return PartialView("_EmptySearch");
            }
            else if (q == "" && p != "")
            {
                var locations = GetLocations(p);

                if (locations.Any())
                {
                    return PartialView("_EventSearch", locations);
                }

                return PartialView("_NoResults");
            }
            else if (q != "" && p != "")
            {
                var eventsbylocation = GetEventsByLocation(q, p);

                if (eventsbylocation.Any())
                {
                    return PartialView("_EventSearch", eventsbylocation);
                }

                return PartialView("_NoResults");
            }
            else
            {
                var locations = GetLocations(p);

                if (locations.Any())
                {
                    return PartialView("_EventSearch", locations);
                }

                return PartialView("_NoResults");
            }

        }

        private List<Event> GetLocations(string searchString)
        {
            return db.Events
                .Where(a => a.Location.Contains(searchString))
                .OrderBy(a => a.EventName)
                .ToList();
        }

        private List<Event> GetEventsByLocation(string q, string p)
        {
            return db.Events
                 .Where(a => a.Location.Contains(q))
                 .OrderBy(a => a.EventName)
                 .ToList();
        }

        private List<Event> GetEvents(string searchString)
        {
            return db.Events
                .Where(a => a.EventName.Contains(searchString) || a.EventDescription.Contains(searchString))
                .OrderBy(a => a.EventName)
                .ToList();
        }

        public ActionResult LastMinuteDeals()
        {
            var events = GetLastMinuteDeals();
            return PartialView("_LastMinuteDeals", events);
        }

        private List<Event> GetLastMinuteDeals()
        {
            var twoDayWindow = DateTime.Now.AddDays(2);
            return db.Events
                .Where(a => a.EventStart <= twoDayWindow)
                .OrderBy(a => a.EventName)
                .ToList();
        }




        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Application Description";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Information";

            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }
    }
}