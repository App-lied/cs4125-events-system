namespace cs4125.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Venue? Venue { get; set; }
        public DateTime DateTime { get; set; }
        public List<IDiscount>? Discounts { get; set; }
        public List<Ticket> Tickets { get; set; }
        public int RemainingTickets { get; set; }
        public Event() { }

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
