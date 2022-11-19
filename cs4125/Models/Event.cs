namespace cs4125.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Venue? Venue { get; set; }
        public DateTime DateTime { get; set; }
    }
}
