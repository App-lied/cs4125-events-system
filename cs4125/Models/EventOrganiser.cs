using cs4125.Models;
using cs4215.models;


namespace cs4125
{
    public class EventOrganiser : IProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Booking> Tickets { get; set; }
        public List<Event> Events { get; set; }
        public void GetProfile()
        {
            Console.WriteLine("Event Organiser Profile");
        }
    }
}
