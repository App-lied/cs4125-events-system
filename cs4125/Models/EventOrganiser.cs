using cs4215.models;

namespace cs4125
{
    public class EventOrganiser : IProfile
    {
        public void GetProfile()
        {
            Console.WriteLine("Event Organiser Profile");
        }
        public List<Event> Events { get; set; }
    }
}
