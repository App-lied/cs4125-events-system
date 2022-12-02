namespace cs4125.Models
{
    public class PremiumUser : Profile
    {
        public List<Booking> Tickets { get; set; }
        public override void GetProfile()
        {
            Console.WriteLine("Premium User Profile");
        }

        //overrides the writeInfoToCSV method to add a premium tag
        public override void writeInfoToCSV()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("Data/LoginInformation.csv", true))
            {
                file.WriteLine(Email + "#" + Password + "#" + Name + "#" + DateOfBirth.ToString()+ "# https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460__340.png" + " # premium");
            }
        }
    }
}
