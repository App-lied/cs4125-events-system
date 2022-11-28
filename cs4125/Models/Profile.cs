namespace cs4125.Models
{
    public abstract class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }

        public abstract void GetProfile();
        public int getAge()
        {
            var now = DateTime.Today;
            var age = now.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > now.AddYears(-age)) age--;
            return age;
        }
        public virtual void writeInfoToCSV()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("Data/LoginInformation.csv", true))
            {
                file.WriteLine(Email + "," + Password + "," + Name + "," + DateOfBirth.Date.ToString());
            }
        }
    }
}