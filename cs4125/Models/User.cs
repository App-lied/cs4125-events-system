namespace cs4125.Models
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Email { get; set; }   
        public DateTime DateOfBirth { get; set; }   
    }
}
