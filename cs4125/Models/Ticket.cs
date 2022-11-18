namespace cs4125.Models
{
    public class Ticket
    {
        public double BasePrice { get; set; }
        public Seat Seat { get; set; }
        public bool Purchased { get; set; }
    }
}
