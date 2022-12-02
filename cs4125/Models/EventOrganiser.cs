using cs4125.Models;
using System.Diagnostics.Tracing;
using System.Linq.Expressions;

namespace cs4125.Models
{
    public class EventOrganiser : Profile
    {
        /// <summary>
        /// Gets the profile of a user.
        /// </summary>
        public List<Event> Events { get; set; }
        public override void GetProfile()
        {
            Console.WriteLine("Event Organiser Profile");

        }

        /// <summary>
        /// Adds acount information to a CSV.
        /// </summary>
        public override void writeInfoToCSV()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("Data/LoginInformation.csv", true))
            {
                file.WriteLine(Email + "#" + Password + "#" + Name + "#" + DateOfBirth.ToString() + "# https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460__340.png" + " # eventOrg");
            }
        }

        /// <summary>
        /// Creates a new list of events.
        /// </summary>
        public void initializeEventList()
        {
            Events = new List<Event>();
        }

        /// <summary>
        /// Creates an event.
        /// </summary>
        /// <param name="name">The name of the event.</param>
        /// <param name="venue">The venue for the event.</param>
        /// <param name="dt">The date and time of the event.</param>
        /// <param name="price">The price of the event.</param>
        public void createEvent(string name, Venue venue, DateTime dt, double price)
        {
            Event ev = new Event(Events.Count + 1, name, venue, dt, price);
            Events.Add(ev);

        }

        /// <summary>
        /// Gets the id of an event.
        /// </summary>
        /// <param name="id">The identifier for the event.</param>
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

        /// <summary>
        /// Lists the events.
        /// </summary>
        public string getListEvents()
        {
            string allEvents = "";

            foreach (Event ev in Events)
            {
                allEvents += ev.getEventDetails();
            }

            return allEvents;
        }

        /// <summary>
        /// Edits the details of an event.
        /// </summary>
        /// <param name="id">The identifier for the event to be edited.</param>
        /// <param name="property">The parameter being edited for the event.</param>
        /// <param name="edit">The new value.</param>
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

        /// <summary>
        /// Removes an event.
        /// </summary>
        /// <param name="ev">The event being cancelled.</param>
        public void deleteEvent(Event ev)
        {
            ev.NotifyObserversCancelled();
            Events.Remove(ev);
        }
    }
}