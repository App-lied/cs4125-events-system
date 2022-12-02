using cs4125.Models;
using System.Diagnostics.Tracing;
using System.Linq.Expressions;

namespace cs4125.Models
{
    public class EventOrganiser : Profile
    {
        public List<Event> Events { get; set; }
        public override void GetProfile()
        {
            Console.WriteLine("Event Organiser Profile");

        }
        public override void writeInfoToCSV()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("Data/LoginInformation.csv", true))
            {
                file.WriteLine(Email + "#" + Password + "#" + Name + "#" + DateOfBirth.ToString() + "# https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460__340.png" + " # eventOrg");
            }
        }

        public void initializeEventList()
        {
            Events = new List<Event>();
        }

        public void createEvent(string name, Venue venue, DateTime dt, double price)
        {
            Event ev = new Event(Events.Count + 1, name, venue, dt, price);
            Events.Add(ev);

        }

        public Event getEvent(int id)
        {
            Event myEv = null;
            foreach (Event ev in Events)
            {
                if (ev.Id == id)
                {
                    myEv = ev;
                }
            }

            return myEv;
        }

        public string getListEvents()
        {
            string allEvents = "";

            foreach (Event ev in Events)
            {
                allEvents += ev.getEventDetails();
            }

            return allEvents;
        }

        public void editEvent(int id, string property, dynamic edit)
        {
            foreach (Event ev in Events)
            {
                if (id == ev.Id)
                {
                    switch (property)
                    {
                        case "Name":
                            ev.Name = edit;
                            break;
                        case "Venue":
                            ev.Venue = edit;
                            break;
                        case "DateTime":
                            ev.DateTime = edit;
                            break;
                        case "price":
                            if (edit < ev.BasePrice) ev.BasePrice = edit;
                            break;
                    }
                    ev.NotifyObservers();
                }
            }
        }

        public void deleteEvent(Event ev)
        {
            ev.NotifyObserversCancelled();
            Events.Remove(ev);
        }

        public void initializeEventList()
        {
            Events = new List<Event>();
        }

        public void createEvent(string name, Venue venue, DateTime dt, double price)
        {
            Event ev = new Event(Events.Count + 1, name, venue, dt, price);
            Events.Add(ev);

        }

        public Event getEvent(int id)
        {
            Event myEv = null;
            foreach (Event ev in Events)
            {
                if (ev.Id == id)
                {
                    myEv = ev;
                }
            }

            return myEv;
        }

        public string getListEvents()
        {
            string allEvents = "";

            foreach (Event ev in Events)
            {
                allEvents += ev.getEventDetails();
            }

            return allEvents;
        }

        public void editEvent(int id, string property, dynamic edit)
        {
            foreach (Event ev in Events)
            {
                if (id == ev.Id)
                {
                    switch (property)
                    {
                        case "Name":
                            ev.Name = edit;
                            break;
                        case "Venue":
                            ev.Venue = edit;
                            break;
                        case "DateTime":
                            ev.DateTime = edit;
                            break;
                        case "price":
                            if (edit < ev.BasePrice) ev.BasePrice = edit;
                            break;
                    }
                    ev.NotifyObservers();
                }
            }
        }

        public void deleteEvent(Event ev)
        {
            Payment p = new Payment();
            p.RefundAll(ev.Bookings);
            ev.NotifyObserversCancelled();
            Events.Remove(ev);
        }
    }
}