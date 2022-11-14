namespace IntroToBDD.Helpers.Settings
{
    public class ContractApiSettings
    {
        public static ContractApiSettings Current { get; } = ConfigurationLoader.LoadContractApiSettings();
        public string Url { get; set; } = string.Empty;
        public Credentials Credentials { get; set; } = new Credentials(string.Empty, string.Empty);
    }
}
