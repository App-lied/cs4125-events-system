using cs4125.Models;
using Microsoft.AspNetCore.Identity;
using System.Drawing;
using System.IO;
using System.Text;

namespace cs4125.Models
{
    public class User : Profile, IProfile
    {
       

        public override void GetProfile()
        {
            Console.WriteLine("User Profile");
        }

        public override void writeInfoToCSV()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("Data/LoginInformation.csv", true))
            {
                file.WriteLine(Email + "#" + Password + "#" + Name + "#" + DateOfBirth.ToString() + "# https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460__340.png" );
            }
        }


    }


}