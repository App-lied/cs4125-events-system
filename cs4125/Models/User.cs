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

    }
}
