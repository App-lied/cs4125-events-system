using cs4125.Models;
using cs4215.models;
using Microsoft.AspNetCore.Identity;
using System.Drawing;
using System.IO;
using System.Text;

namespace cs4125.models
{
    public class User : IProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Booking> Tickets { get; set; }

        public void GetProfile()
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
    }
}
