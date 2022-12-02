namespace cs4125.Models
{

    /// <summary>
    /// Class <c> Booking </c> models a booking.
    /// </summary>
    public class Booking
    {
        public int Id { get; set; }
        public Profile User { get; set; }
        public Event @event { get; set; }
        public int ticketsPurchased { get; set; }
        public double Paid { get; set; }


        /// <summary>
        /// Constructor for a <c>Booking</c>. 
        /// </summary>
        /// <param name="id">The identifier for the booking.</param>
        /// <param name="user">The user making the booking.</param>
        /// <param name="event">TThe event being booked.</param>
        /// <param name="ticketsPurchased">Amount of tickets being booked.</param>
        /// <param name="paid">Cost of the booking.</param>
        public Booking(int id, Profile user, Event @event, int ticketsPurchased, double paid)
        {
            this.Id = id;
            this.User = user;
            this.@event = @event;
            this.ticketsPurchased = ticketsPurchased;
            Paid = paid;
        }

        /// <summary>
        /// Creates a new <c>Booking</c>. 
        /// </summary>
        /// <param name="id">The identifier for the booking.</param>
        /// <param name="user">The user making the booking.</param>
        /// <param name="event">TThe event being booked.</param>
        /// <param name="ticketsPurchased">Amount of tickets being booked.</param>
        /// <param name="paid">Cost of the booking.</param>
        public static Booking createBooking(int id, Profile user, Event @event, int ticketspurchased, double paid)
        {
            return new Booking(id, user, @event, ticketsPurchased, paid);
        }

        /// <summary>
        /// Updates tickets availablitiy, available in the event being booked. 
        /// </summary>
        /// <param name="ev">TThe event being booked.</param>
        /// <param name="block">Block of seats where the user whats to sit.</param>
        public Ticket getTicket(Event ev, char block)
        {
            Ticket myTicket = null;
            foreach (Ticket t in ev.Tickets)
            {
                if (t.Purchased == false && t.Seat.Block.Id == block)
                {
                    myTicket = t;
                    break;

                }
            }
            return myTicket;
        }


        public Ticket refundTicket(Event ev, char block)
        {
            Ticket myTicket = null;
            foreach (Ticket t in ev.Tickets)
            {
                if (t.Purchased == true && t.Seat.Block.Id == block)
                {
                    myTicket = t;
                    break;

                }
            }
            return myTicket;
        }
        
        /// <summary>
        /// Returns the booking details as a string. 
        /// </summary>
        public string getBookingDetails()
        {
            return ($"{@event.getEventDetails()}Tickets purchased: {ticketsPurchased}; Paid {Paid}\n");
        }
    }


}