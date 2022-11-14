using IntroToBDD.Helpers.Settings;

namespace IntroToBDD.Helpers.TokenFetching
{
    public class TokenFeatureContext
    {
        private readonly TokenFeatureHelper _helper = new TokenFeatureHelper();
        public string Url { get; } = ContractApiSettings.Current.Url;
        public Credentials Credentials { get; } = ContractApiSettings.Current.Credentials;

        public HttpResponseMessage Login(Credentials credentials) =>
            _helper.Login(Url, credentials.Username, credentials.Password);
    }
}
