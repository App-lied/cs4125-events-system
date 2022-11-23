using cs4125.Models;
using System;
namespace cs4215.models
{
    public interface IProfile
    {
        void GetProfile();
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Booking> Tickets { get; set; }
        public void writeInfoToCSV()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\Users\\Conor\\Documents\\CollegeWork\\LoginInformation.csv", true))
            {
                file.WriteLine(Email + "," + Name + "," + DateOfBirth.ToString());
            }
        }
    }
}