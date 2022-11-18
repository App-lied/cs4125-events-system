namespace cs4125.Models
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Event> Events { get; set; }
        public List<Block> Blocks { get; set; }
    }

    public class Block
    {
        public string Id { get; set; }
        public List<Seat> Seats { get; set; }
        public double Premium { get; set; }
    }

    public class Seat
    {
        public string Id { get; set; }
        public Block Block { get; }
    }
}
