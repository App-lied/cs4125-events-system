using System.Diagnostics.CodeAnalysis;

namespace cs4125.Models
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Email { get; set; }   
        public DateTime DateOfBirth { get; set; }

        public int getAge()
        {
            var now = DateTime.Today;
            var age = now.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > now.AddYears(-age)) age--;
            return age;
        }
    }
}
