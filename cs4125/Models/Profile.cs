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
        public List<Ticket> Tickets { get; set; }

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
            Bookings = new List<Booking>();
            Tickets = new List<Ticket>();
        }

        public void makeBooking(Event ev, char block, int amount)
        {
            int x = 1;
            Booking b = new Booking(Bookings.Count + 1, this, ev, amount, 0.0);
            Bookings.Add(b);
            createEventObserver(ev);
            while (x <= amount)
            {
                Ticket t = b.getTicket(ev, block);
                Tickets.Add(t);
                ev.updateAvailableTickets(t, true);
                x++;

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