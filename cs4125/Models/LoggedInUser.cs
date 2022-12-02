using static System.Net.WebRequestMethods;

class LoggedInUser
{
    private LoggedInUser() { }

    private static LoggedInUser _instance;

    // We now have a lock object that will be used to lock the login
    // during first access to the Singleton.
    private static readonly object _lock = new object();

    public static LoggedInUser GetInstance(string email, string password, string name, string photo = "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460__340.png", bool createIfNeeded = true)
    {
        // This conditional is needed to prevent threads stumbling over the
        // lock once the instance is ready. And will prevent null values being called if createIfNeeded is false
        if (_instance == null && createIfNeeded)
        {
            // There's no Singleton instance yet, a login will
            // pass the previous conditional and reach this
            // point. The first of login will acquire the lock
            lock (_lock)
            {
                // The first login goes inside and creates the Singleton
                // instance. Once it leaves the lock block, any other logins
                // won't be able to change the value. Because now the Singleton field is
                // already initialized, the call won't create a new
                // object.
                if (_instance == null)
                {
                    _instance = new LoggedInUser();
                    _instance.Email = email;
                    _instance.Password = password;
                    _instance.Name = name;
                    _instance.photo = photo;
                }
            }
        }
        return _instance;
    }

    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string photo { get; set; }


}
