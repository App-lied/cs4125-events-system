using cs4125.Models;
using cs4215.models;

namespace cs4125.models
{
    public class User : IProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Booking> Tickets { get; set; }

        public void GetProfile()
        {
            Console.WriteLine("User Profile");
        }

        public string test()
        {
            return "is this working butt butt";
        }
        
    }
}
