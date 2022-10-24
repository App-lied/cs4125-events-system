namespace cs4125.Models
{
    public class Event
    {
        public string Name { get; set; }

        public Venue Venue { get; set; }
        
        public DateTime DateTime { get; set; }
    }
}
