namespace cs4125.Models
{
    /// <summary>
    /// Class <c> Event </c> models an event and available tickets.
    /// </summary>
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Venue Venue { get; set; }
        public DateTime DateTime { get; set; }
        public List<IDiscount>? Discounts { get; set; }
        public List<Ticket> Tickets { get; set; }
        public int RemainingTickets { get; set; }

        /// <summary>
        /// Constructor for an <c>Event</c>. Creates a new <c>Ticket</c> for each seat in the venue.
        /// </summary>
        /// <param name="id">The identifier for the event.</param>
        /// <param name="name">The title of the event.</param>
        /// <param name="venue">The venue where the event is held.</param>
        /// <param name="dt">The date and time of the event.</param>
        /// <param name="basePrice">The base price of a ticket for the event.</param>
        public Event(int id, string name, Venue venue, DateTime dt, double basePrice) { 
            Id = id;
            Name = name;
            Venue = venue;
            DateTime = dt;
            Discounts= new List<IDiscount>();
            Tickets = new List<Ticket>();  

            foreach (Block b in venue.Blocks) { 
                foreach (Seat s in b.Seats)
                {
                    Tickets.Add(Ticket.createTicket(basePrice, s));
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
            if(purchased == true)
            {
                t.Purchased = purchased;
                RemainingTickets--;
            } else
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
    }
}
