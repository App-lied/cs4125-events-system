namespace cs4125.Models
{
    public abstract class Profile
    {
        //is the abstract class from which User, Premium User, and Event Organiser inherits from
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }

        public abstract void GetProfile();
        public int getAge()
        {
            //subtracts the date of birth from the current date to get the age
            var now = DateTime.Today;
            var age = now.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > now.AddYears(-age)) age--;
            return age;
        }
        public virtual void writeInfoToCSV()
        {
            //writes the information thats been passed in to the data csv, and sets the photo to be the basic profile photo
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("Data/LoginInformation.csv", true))
            {
                file.WriteLine(Email + "," + Password + "," + Name + "," + DateOfBirth.Date.ToString()+ ", https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460__340.png");
            }
        }
    }
}