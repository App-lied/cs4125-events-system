namespace cs4125.Models
{
    public class Customer : User
    {
        public List<Booking> Bookings { get; set; }
    }
}
