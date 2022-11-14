namespace IntroToBDD.Helpers.Settings
{
    public class Credentials
    {
        public string User { get; }
        public string Password { get; }
        public Credentials(string user, string password)
        {
            User = user;
            Password = password;
        }
    }
}
