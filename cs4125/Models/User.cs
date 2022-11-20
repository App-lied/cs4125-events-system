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

        public int getAge()
        {
            var now = DateTime.Today;
            var age = now.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > now.AddYears(-age)) age--;
            return age;
        }
    }
}
