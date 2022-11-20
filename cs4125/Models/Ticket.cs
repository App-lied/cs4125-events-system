namespace cs4125.Models
{
    public class Ticket
    {
        public double BasePrice { get; set; }
        public Seat Seat { get; set; }
        public bool Purchased { get; set; }

        public Ticket(double p, Seat s)
        {
            BasePrice = p;
            Seat = s;
            Purchased = false;
        }

        public static Ticket createTicket(double p, Seat s) { 
            return new Ticket(price, s);
        }
    }
}
