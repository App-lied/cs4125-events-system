using Microsoft.AspNetCore.Hosting.Server;
using System;
using System.Transactions;

namespace cs4125.Models
{
    /// <summary>
    /// Class <c> Event </c> models an event and available tickets.
    /// </summary>
    public class Event : IEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Venue Venue { get; set; }
        public DateTime DateTime { get; set; }
        public double BasePrice { get; set; }
        public List<IDiscount>? Discounts { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Booking> Bookings { get; set; }
        public int RemainingTickets { get; set; }
        private List<IProfile> observers = new List<IProfile>();

        /// <summary>
        /// Constructor for an <c>Event</c>. Creates a new <c>Ticket</c> for each seat in the venue.
        /// </summary>
        /// <param name="id">The identifier for the event.</param>
        /// <param name="name">The title of the event.</param>
        /// <param name="venue">The venue where the event is held.</param>
        /// <param name="dt">The date and time of the event.</param>
        /// <param name="basePrice">The base price of a ticket for the event.</param>
        public Event(int id, string name, Venue venue, DateTime dt, double basePrice)
        {
            Id = id;
            Name = name;
            Venue = venue;
            DateTime = dt;
            BasePrice = basePrice;
            RemainingTickets = venue.Capacity;
            Discounts = new List<IDiscount>();
            Tickets = new List<Ticket>();
            Bookings = new List<Booking>();

            foreach (Block b in Venue.Blocks)
            {
                foreach (Seat s in b.Seats)
                {
                    Tickets.Add(Ticket.createTicket(BasePrice, s));
                }
            }

        }

        /// <summary>
        /// Creates a new <c>Event</c>.
        /// </summary>
        /// <param name="id">The identifier for the event.</param>
        /// <param name="name">The title of the event.</param>
        /// <param name="venue">The venue where the event is held.</param>
        /// <param name="dt">The date and time of the event.</param>
        /// <param name="basePrice">The base price of a ticket for the event.</param>
        public static Event createEvent(int id, string name, Venue venue, DateTime dt, double basePrice)
        {
            return new Event(id, name, venue, dt, basePrice);
        }

        /// <summary>
        /// Updates a <c>Ticket</c> instance and the remaining capacity of the event when the ticket is either purchased or refunded.
        /// </summary>
        /// <param name="t">The ticket to be updated.</param>
        /// <param name="purchased">Whether the ticket was purchased or refunded.</param>
        public void updateAvailableTickets(Ticket t, bool purchased)
        {
            if (purchased == true)
            {
                t.Purchased = purchased;
                RemainingTickets--;
            }
            else
            {
                t.Purchased = purchased;
                RemainingTickets++;
            }
        }

        /// <summary>
        /// Adds a new discount to the event.
        /// </summary>
        /// <param name="d">The discount to be added.</param>
        public void addDiscount(IDiscount d)
        {
            Discounts.Add(d);
        }

        /// <summary>
        /// Checks if amount wanted less then remaining tickets.
        /// </summary>
        /// <param name="amount">The number of tickets wanted.</param>
        public bool isEventAvailable(int amount) { if (amount<= RemainingTickets) { return true; } ; return false; }


        /// <summary>
        /// AAdd a new booking to the event.
        /// </summary>
        /// <param name="b">The booking to be added.</param>
        public void AddBooking(Booking b)
        {
            Bookings.Add(b);
        }

        /// <summary>
        /// Calls the add observer method to register a new profile watching the event.
        /// </summary>
        /// <param name="observer">The profile that is observing the event.</param>
        public void RegisterObserver(IProfile observer)
        {
            Console.WriteLine($"Observer Added : {((User)observer).Name}\n");
            observers.Add(observer);
        }

        /// <summary>
        /// Adds an observer to the event.
        /// </summary>
        /// <param name="observer">The profile that is observing the event.</param>
        public void AddObservers(IProfile observer)
        {
            observers.Add(observer);
        }

        /// <summary>
        /// Removed an observer from the event.
        /// </summary>
        /// <param name="observer">The profile that is being removed from observing the event.</param>
        public void RemoveObserver(IProfile observer)
        {
            observers.Remove(observer);
        }

        ///////////

        /// <summary>
        /// Notify observers that the event was updated.
        /// </summary>
        public void NotifyObservers()
        {
            Console.WriteLine($"Event :{this.Name} has been edited.\n");
            foreach (IProfile observer in observers)
            {
                observer.updateEvent(this);
            }
        }

        /// <summary>
        /// Notify the observersthe event was cancelled.
        /// </summary>
        public void NotifyObserversCancelled()
        {
            Console.WriteLine($"Event :{this.Name} has been canceled.\n");
            foreach (IProfile observer in observers)
            {
                observer.updateEventCancelled(this);
            }
        }

        /// <summary>
        /// Gets details about the event.
        /// </summary>
        public string getEventDetails()
        {
            return ($"Name: {Name}; Date: {DateTime}\nTickets Available: {RemainingTickets}; Price: {BasePrice}\n{Venue.getVenueDetails()}\n");
        }
    }
}