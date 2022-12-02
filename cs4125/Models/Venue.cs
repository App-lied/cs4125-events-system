namespace cs4125.Models
{
    /// <summary>
    /// Class <c>Venue</c> models a venue that hosts events.
    /// </summary>
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Event>? Events { get; set; }
        public List<Block>? Blocks { get; set; }
        public int Capacity { get; set; }

        /// <summary>
        /// Constructor for a <c>Venue</c>.
        /// </summary>
        /// <param name="id">The identifier for the venue.</param>
        /// <param name="name">The name of the venue.</param>
        /// <param name="address">The location of the venue.</param>
        public Venue(int id, string name, string address)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            Blocks = new List<Block>();
            Events = new List<Event>();
        }

        /// <summary>
        /// Creates a new <c>Venue</c>.
        /// </summary>
        /// <param name="id">The identifier for the venue.</param>
        /// <param name="name">The name of the venue.</param>
        /// <param name="address">The location of the venue.</param>
        public static Venue createVenue(int id, string name, string address)
        {
            return new Venue(id, name, address);
        }

        /// <summary>
        /// Adds a new <c>Block</c> to the venue. Updates the venue's capacity with the block's.
        /// </summary>
        /// <param name="block">The block to add.</param>
        public void addBlock(Block block)
        {
            Blocks.Add(block);
            Capacity += block.Capacity;
        }

        /// <summary>
        /// Gets the details of a venue.
        /// </summary>
        public string getVenueDetails()
        {
            string tempCapacity = "";
            for (int i = 0; i < Blocks.Count; i++)
            {
                tempCapacity = tempCapacity + "Block " + Blocks[i].Id + ": " + Blocks[i].Capacity + "\n\t";
            }

            return ($"Venue: {Name}\nAddress: {Address}\n");
        }
    }

    /// <summary>
    /// Class <c>Block</c> models a block of seats within a venue.
    /// </summary>
    public class Block
    {
        public char Id { get; set; }
        public List<Seat> Seats { get; set; }
        public int Capacity { get; set; }
        public double Premium { get; set; }

        /// <summary>
        /// Constructor for a <c>Block</c>. Creates and adds new seats up to the capacity.
        /// </summary>
        /// <param name="id">The identifier for the block, e.g: A, B, C, etc.</param>
        /// <param name="cap">The capacity of the block.</param>
        /// <param name="prem">The the premium applied to ticket prices in the block.</param>
        public Block(char id, int cap, double prem)
        {
            Id = id;
            Capacity = cap;
            Premium = prem;

            Seats = new List<Seat>();
            for (int i = 1; i <= Capacity; i++)
            {
                Seats.Add(Seat.createSeat(i, this));
            }
        }

        /// <summary>
        /// Creates a new <c>Block</c>.
        /// </summary>
        /// <param name="id">The identifier for the block, e.g: A, B, C, etc.</param>
        /// <param name="cap">The capacity of the block.</param>
        /// <param name="prem">The the premium applied to ticket prices in the block.</param>
        public static Block createBlock(char id, int cap, double prem)
        {
            return new Block(id, cap, prem);
        }
    }

    /// <summary>
    /// Class <c>Seat</c> models a seat within a block, within a venue.
    /// </summary>
    public class Seat
    {
        public int Id { get; set; }
        public Block Block { get; }

        /// <summary>
        /// Constructor for a <c>Seat</c>.
        /// </summary>
        /// <param name="id">The identifier for the seat.</param>
        /// <param name="block">The block the seat is in.</param>
        public Seat(int id, Block block)
        {
            Id = id;
            Block = block;
        }

        /// <summary>
        /// Creates a new <c>Seat</c>.
        /// </summary>
        /// <param name="id">The identifier for the seat.</param>
        /// <param name="block">The block the seat is in.</param>
        public static Seat createSeat(int id, Block Block)
        {
            return new Seat(id, Block);
        }
    }
}