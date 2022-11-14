namespace IntroToBDD.Helpers.Settings
{
    public class Credentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Credentials()
        {

        }
        public Credentials(string user, string password)
        {
            Username = user;
            Password = password;
        }
    }
}
