using Microsoft.CodeAnalysis.Differencing;

namespace cs4125.Models
{
    public abstract class Profile : IProfile
    {
        //is the abstract class from which User, Premium User, and Event Organiser inherits from
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Booking> Bookings { get; set; }
        public List<Booking> pendingBookings { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Ticket> Cart { get; set; }
        public int Points { get; set; }


        public abstract void GetProfile();
        public int getAge()
        {
            //subtracts the date of birth from the current date to get the age
            var now = DateTime.Today;
            var age = now.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > now.AddYears(-age)) age--;
            return age;
        }
        public virtual void writeInfoToCSV()
        {
            //writes the information thats been passed in to the data csv, and sets the photo to be the basic profile photo
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("Data/LoginInformation.csv", true))
            {
                file.WriteLine(Email + "#" + Password + "#" + Name + "#" + DateOfBirth.Date.ToString()+ "# https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460__340.png");
            }
        }

        public void initializeLists()
        {
            Cart = new List<Ticket>();
            pendingBookings = new List<Booking>();
            Bookings = new List<Booking>();
            Tickets = new List<Ticket>();
            Points = 300;
        }

        /// <summary>
        /// Check if user has sufficient funds.
        /// </summary>
        /// <param name="points">Points needed are less then points the user has.</param>
        public bool sufficientPoints(int points) { if (points <= Points) { return true; }; return false; }

        /// <summary>
        /// Check if user is old enough.
        /// </summary>
        public bool appropriateAge() { if (16 <= getAge()) { return true; }; return false; }

        /// <summary>
        /// Temporarily store tickets until user purchases them.
        /// </summary>
        /// <param name="ev">Event for which ticket is being wanted.</param>
        /// <param name="block">Block in which ticket is located.</param>
        /// <param name="amount">Number of tickets.</param>
        public void addToCart(Event ev, char block, int amount)
        {
            int x = 1;
            Booking b = new Booking(Bookings.Count + 1, this, ev, amount, 0.0);
            pendingBookings.Add(b);

            if (ev.RemainingTickets >= amount)
            {
                while (x <= amount )
                {
                    Cart.Add(b.getTicket(ev, block));
                    x++;

                }
            }
            else
            {
                Console.WriteLine($"Requested amount of tickets unavailable. Amount available : {ev.RemainingTickets}\n");
            }
        }

        /// <summary>
        /// Adds points to user.
        /// </summary>
        /// <param name="points">Amount of points being topped up.</param>
        public void topPointsUp(int points)
        {
            Payment p = new Payment();
            p.topUpPoints(this, points);
        }


        /// <summary>
        /// Facade design pattern, used to call multiple methods to confirm user is eligable to buy ticket(s).
        /// </summary>
        /// <param name="ev">The event.</param>
        /// <param name="amount">Amount of tickets being purchased.</param>
        public bool isEligable(Event ev, int amount)
        {
            Console.WriteLine($"{this.Name} started transaction for {ev.Name} tickets\n");
            bool eligible = true;

            if (!(ev.isEventAvailable(amount)))
            {
                Console.WriteLine($"Requested amount of tickets unavailable, Transaction stopped.\nAmount available : {ev.RemainingTickets}\n");
                eligible = false;
            }
            else if (!sufficientPoints((int)ev.BasePrice * amount))
            {
                Console.WriteLine($"Insuffient amount of points\n");
                eligible = false;
            }
            else if (!appropriateAge())
            {
                eligible = false;
            }
            return eligible;
        }

        /// <summary>
        /// Pay for tickets in cart.
        /// </summary>
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

        /// <summary>
        /// Refunds the user.
        /// </summary>
        /// <param name="booking">Booking to be refunded.</param>
        /// /// <param name="block">Block in which ticket is located.</param>
        public void refundTickets(Booking booking, char block)
        {

            foreach (Booking b in Bookings.ToList())
            {
                if (b == booking)
                {
                    int x = 1;

                    while (x <= b.ticketsPurchased)
                    {
                        Ticket t = b.refundTicket(b.@event, block);
                        b.@event.updateAvailableTickets(t, false);
                        x++;

                    }

                    Bookings.Remove(b);
                    removeEventObserver(b.@event);


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

        public void removeEventObserver(IEvent ev)
        {

            ev.RemoveObserver(this);
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