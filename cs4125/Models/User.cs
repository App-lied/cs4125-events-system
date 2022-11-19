using cs4215.models;

namespace cs4125.models
{
    public class User : IProfile
    {
        public void GetProfile()
        {
            Console.WriteLine("User Profile");
        }

        public int Id { get; set; }
        public string Email { get; set; }   
        public DateTime DateOfBirth { get; set; }   
    }
}
