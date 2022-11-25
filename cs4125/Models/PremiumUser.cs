namespace cs4125.Models
{
    public class PremiumUser : Profile
    {
        public List<Booking> Tickets { get; set; }
        public override void GetProfile()
        {
            Console.WriteLine("Premium User Profile");
        }

        public override void writeInfoToCSV()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("Data/LoginInformation.csv", true))
            {
                file.WriteLine(Email + "," + Name + "," + DateOfBirth.ToString()+",premium");
            }
        }
    }
}
