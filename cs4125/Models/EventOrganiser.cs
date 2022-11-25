using cs4125.Models;

namespace cs4125.Models
{
    public class EventOrganiser : Profile
    {
        public List<Event> Events { get; set; }
        public override void GetProfile()
        {
            Console.WriteLine("Event Organiser Profile");
        }
    }
}
