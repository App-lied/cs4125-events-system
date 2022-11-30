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
                file.WriteLine(Email + "," + Password + "," + Name + "," + DateOfBirth.Date.ToString()+ ", https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460__340.png");
            }
        }
    }
}