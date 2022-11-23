using cs4215.models;

namespace cs4125.Models
{
    public class PremiumUser : IProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Booking> Tickets { get; set; }
        public void GetProfile()
        {
            Console.WriteLine("Premium User Profile");
        }

        public void writeInfoToCSV()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\Users\\Conor\\Documents\\CollegeWork\\LoginInformation.csv", true))
            {
                file.WriteLine(Email + "," + Name + "," + DateOfBirth.ToString()+",premium");
            }
        }
    }
}
