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
        public override void writeInfoToCSV()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("Data/LoginInformation.csv", true))
            {
                file.WriteLine(Email + "," + Password + "," + Name + "," + DateOfBirth.ToString() + ", https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460__340.png" + " , eventOrg");
            }
        }
    }
}
