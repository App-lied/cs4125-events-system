namespace cs4125.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Venue Venue { get; set; }
        public DateTime DateTime { get; set; }
        public List<IDiscount>? Discounts { get; set; }
        public List<Ticket> Tickets { get; set; }
        public int RemainingTickets { get; set; }
        
        public Event(int id, string name, Venue venue, DateTime dt) { 
            Id = id;
            Name = name;
            Venue = venue;
            DateTime = dt;
            Discounts= new List<IDiscount>();
            Tickets = new List<Ticket>();   
        }

        public static Event createEvent(int id, string name, Venue venue, DateTime dt)
        {
            return new Event(id, name, venue, dt);
        }

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

        public void addDiscount(IDiscount d)
        {
            Discounts.Add(d);
        }
    }
}
