namespace cs4125.Models
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Event>? Events { get; set; }
        public List<Block>? Blocks { get; set; }
        public int Capacity { get; set; }
        

        public Venue(int id, string name, string address) {
            this.Id = id;
            this.Name = name;  
            this.Address = address;
            Blocks = new List<Block>();
            Events = new List<Event>();
        }

        public static Venue createVenue(int id, string name, string address)
        {
            return new Venue(id, name, address);
        }

        public void addBlock(Block block)
        {
            Blocks.Add(block);
            Capacity += block.Capacity;
        }
    }

    public class Block
    {
        public string Id { get; set; }
        public List<Seat> Seats { get; set; }
        public int Capacity { get; set; }
        public double Premium { get; set; }

        public Block(string id, int cap, double prem)
        {
            Id = id;
            Capacity = cap;
            Premium = prem;
            for(int i = 1; i <= Capacity; i++)
            {
                Seats.Add(Seat.createSeat(i.ToString(), this));
            }
        }

        public static Block createBlock(string id, int cap, double prem)
        {
            return new Block(id, cap, prem);
        }
    }

    public class Seat
    {
        public string Id { get; set; }
        public Block Block { get; }

        public Seat(string id, Block block)
        {
            Id = id;
            Block = block;
        }

        public static Seat createSeat(string id, Block Block)
        {
            return new Seat(id, Block);
        }
    }
}
