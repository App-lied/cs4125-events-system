
using Microsoft.CodeAnalysis.Differencing;

namespace cs4125.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public Profile User { get; set; }
        public Event @event { get; set; }
        public int ticketsPurchased { get; set; }
        public double Paid { get; set; }

        public Booking(int id, Profile user, Event @event, int ticketsPurchased, double paid)
        {
            this.Id = id;
            this.User = user;
            this.@event = @event;
            this.ticketsPurchased = ticketsPurchased;
            Paid = paid;
        }

        public static Booking createBooking(int id, Profile user, Event @event, int ticketspurchased, double paid)
        {
            return new Booking(id, user, @event, ticketspurchased, paid);
        }

        

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


        public string getBookingDetails()
        {
            return ($"{@event.getEventDetails()}Tickets purchased: {ticketsPurchased}; Paid {Paid}\n");
        }
    }


}