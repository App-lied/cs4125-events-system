using cs4125.Models;
using Microsoft.AspNetCore.Identity;
using System.Drawing;
using System.IO;
using System.Text;

namespace cs4125.Models
{
    public class User : Profile
    {
        public List<Booking> Tickets { get; set; }

        public override void GetProfile()
        {
            Console.WriteLine("User Profile");
        }

        public int getAge()
        {
            var now = DateTime.Today;
            var age = now.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > now.AddYears(-age)) age--;
            return age;
        }

        public override void writeInfoToCSV()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("Data/LoginInformation.csv", true))
            {
                file.WriteLine(Email + "," + Name + "," + DateOfBirth.ToString());
            }
        }
    }
}
