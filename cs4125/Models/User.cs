using cs4125.Models;
using Microsoft.AspNetCore.Identity;
using System.Drawing;
using System.IO;
using System.Text;

namespace cs4125.Models
{
    public class User : Profile, IProfile
    {
        public List<Booking> Bookings { get; set; }
        public List<Booking> pendingBookings { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Ticket> Cart { get; set; }
        public int Points { get; set; }

        public override void GetProfile()
        {
            Console.WriteLine("User Profile");
        }

        public void initializeLists()
        {
            Cart = new List<Ticket>();
            pendingBookings = new List<Booking>();
            Bookings = new List<Booking>();
            Tickets = new List<Ticket>();
            Points = 300;
        }

        public void addToCart(Event ev, char block, int amount)
        {
            int x = 1;
            Booking b = new Booking(Bookings.Count + 1, this, ev, amount, 0.0);
            pendingBookings.Add(b);

            while (x <= amount)
            {
                Cart.Add(b.getTicket(ev, block));
                x++;

            }

        }

        public void topPointsUp(int points)
        {
            Payment p = new Payment();
            p.topUpPoints(this, points);
        }

        public void payForTickets()
        {
            if (Cart.Count != 0)
            {
                Payment p = new Payment();

                if (p.makePayemnt(this, Cart, pendingBookings[0].@event).Item1 == true)
                {
                    double Paid = p.makePayemnt(this, Cart, pendingBookings[0].@event).Item2;
                    createEventObserver(pendingBookings[0].@event);
                    pendingBookings[0].Paid = Paid;

                    foreach (Ticket t in Cart)
                    {
                        pendingBookings[0].@event.updateAvailableTickets(t, true);
                    }

                    pendingBookings[0].@event.AddBooking(pendingBookings[0]);

                    Tickets.AddRange(Cart);
                    Cart.Clear();
                    Bookings.AddRange(pendingBookings);
                    pendingBookings.Clear();


                }
            }
        }

        public void refundTickets(Booking booking, char block)
        {

            foreach (Booking b in Bookings.ToList()) { 
                if (b == booking)
                {
                    int x = 1;

                    while (x <= b.ticketsPurchased)
                    {
                        b.refundTicket(b.@event, block);
                        x++;

                    }

                    Bookings.Remove(b);
                    

                    foreach (Ticket t in Tickets.ToList())
                    {
                        if (t.Seat.Block.Id == block)
                        {
                            Tickets.Remove(t);
                        }
                    }
                }
            }
        }

        public string getBookings()
        {
            string bookingsString = "";
            foreach (Booking b in Bookings)
            {
                bookingsString += b.getBookingDetails();
            }
            return bookingsString;
        }

        public void createEventObserver(IEvent ev)
        {

            ev.RegisterObserver(this);
        }

        public void updateEvent(Event ev)
        {
            Console.WriteLine($"Hello {Name}, an event in your bookings has been updated.\nEvent updated is: {ev.Name}\n");
        }

        public void updateEventCancelled(Event ev)
        {
            foreach (Booking b in Bookings)
            {
                if (b.@event == ev)
                {
                    Console.WriteLine($"Hello {Name}.\nEvent {ev.Name} has been cancelled.\n Here is your refund of {b.Paid}");
                }
            }

        }



    }


}