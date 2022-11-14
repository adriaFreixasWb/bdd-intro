using IntroToBDD.Helpers;
using System.Net;

namespace IntroToBDD.Test.StepDefinitions
{
    [Binding]
    public class TokenFetchingSteps
    {
        private readonly TokenFeatureHelper tokenFeatureHelper;
        private readonly ScenarioContext context;
        private const string url = "http://cmicts10.internal.stage.aws.dotw.com/api/verticalbooking/v1/authorize.json";
        private string user;
        private string password;
        public TokenFetchingSteps(ScenarioContext context)
        {
            tokenFeatureHelper= new TokenFeatureHelper();
            this.context = context;
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
            
            var response = tokenFeatureHelper.Login(url, user, password);
            context.Add(nameof(HttpResponseMessage), response);
        }

        [Then(@"We should get unauthorized")]
        public void ThenWeShouldGetUnauthorized()
        {
            var response = context.Get<HttpResponseMessage>(nameof(HttpResponseMessage));
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}
