namespace cs4125.Models
{
    public class PremiumUser : Profile
    {
        public List<Booking> Tickets { get; set; }
        public override void GetProfile()
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
