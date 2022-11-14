using IntroToBDD.Helpers.Settings;
using IntroToBDD.Helpers.TokenFetching;
using System.Net;

namespace IntroToBDD.Test.StepDefinitions
{
    [Binding]
    public class TokenFetchingSteps
    {
        private readonly TokenFeatureContext tokenContext;

        public TokenFetchingSteps(TokenFeatureContext tokenContext)
        {
            this.tokenContext = tokenContext;
        }

        [Given(@"That we have a wrong user and a password")]
        public void GivenThatWeHaveAWrongUserAndAPassword()
        {
            tokenContext.Credentials = new Credentials("user", "password");
        }

        [Given(@"That we have correct credentials")]
        public void GivenThatWeHaveCorrectCredentials()
        {
            tokenContext.Credentials = tokenContext.CrednetialsFromSettings();
        }

        [When(@"We log request a new token")]
        public void WhenWeLogRequestANewToken()
        {
            tokenContext.Response = tokenContext.Login(tokenContext.Credentials);
        }

        [Then(@"We should get unauthorized")]
        public void ThenWeShouldGetUnauthorized()
        {
            tokenContext.Response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
        
        [Then(@"We should get success")]
        public void ThenWeShouldGetSuccess()
        {
            tokenContext.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

    }
}
