using IntroToBDD.Helpers.Settings;
using IntroToBDD.Helpers.TokenFetching;
using System.Net;

namespace IntroToBDD.Test.StepDefinitions
{
    [Binding]
    public class TokenFetchingSteps
    {
        private readonly ScenarioContext context;
        private readonly TokenFeatureContext tokenContext;

        public TokenFetchingSteps(ScenarioContext context, TokenFeatureContext tokenContext)
        {
            this.context = context;
            this.tokenContext = tokenContext;
        }

        [Given(@"That we have a wrong user and a password")]
        public void GivenThatWeHaveAWrongUserAndAPassword()
        {
            context.Add(nameof(Credentials), new Credentials("user", "password"));
        }

        [Given(@"That we have correct credentials")]
        public void GivenThatWeHaveCorrectCredentials()
        {
            context.Add(nameof(Credentials), ContractApiSettings.Current.Credentials);
        }

        [When(@"We log request a new token")]
        public void WhenWeLogRequestANewToken()
        {
            var credentials = context.Get<Credentials>(nameof(Credentials));
            var response = tokenContext.Login(credentials);
            context.Add(nameof(HttpResponseMessage), response);
        }

        [Then(@"We should get unauthorized")]
        public void ThenWeShouldGetUnauthorized()
        {
            var response = context.Get<HttpResponseMessage>(nameof(HttpResponseMessage));
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
        
        [Then(@"We should get success")]
        public void ThenWeShouldGetSuccess()
        {
            var response = context.Get<HttpResponseMessage>(nameof(HttpResponseMessage));
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

    }
}
