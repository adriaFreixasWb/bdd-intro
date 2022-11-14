using IntroToBDD.Helpers.Settings;

namespace IntroToBDD.Helpers.TokenFetching
{
    public class TokenFeatureContext
    {
        private readonly TokenFeatureHelper _helper = new TokenFeatureHelper();
        private string url = ContractApiSettings.Current.Url;
        public Credentials Credentials { get; set; }
        public HttpResponseMessage Response { get; set; }

        public HttpResponseMessage Login(Credentials credentials) =>
            _helper.Login(url, credentials.Username, credentials.Password);

        public Credentials CrednetialsFromSettings()=>
             ContractApiSettings.Current.Credentials;

    }
}
