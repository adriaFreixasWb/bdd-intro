using IntroToBDD.Helpers;
using System.Net;

namespace IntroToBDD.Test.StepDefinitions
{
    [Binding]
    public class TokenFetchingSteps
    {
        private readonly TokenFeatureHelper tokenFeatureHelper; 
        private const string url = "http://cmicts10.internal.stage.aws.dotw.com/api/verticalbooking/v1/authorize.json";
        private string user;
        private string password;
        private HttpResponseMessage response;
        public TokenFetchingSteps()
        {
            tokenFeatureHelper= new TokenFeatureHelper();
        }

        [Given(@"That we have a wrong user and a password")]
        public void GivenThatWeHaveAWrongUserAndAPassword()
        {
            user = "user";
            password = "password";
        }

        [When(@"We log request a new token")]
        public void WhenWeLogRequestANewToken()
        {
            response = tokenFeatureHelper.Login(url, user, password);
        }

        [Then(@"We should get unauthorized")]
        public void ThenWeShouldGetUnauthorized()
        {
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}
