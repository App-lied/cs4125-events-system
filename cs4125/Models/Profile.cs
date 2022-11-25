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
        public abstract void writeInfoToCSV();
    }
}