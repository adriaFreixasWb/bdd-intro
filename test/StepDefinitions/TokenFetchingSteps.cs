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

        public TokenFetchingSteps(ScenarioContext context)
        {
            tokenFeatureHelper= new TokenFeatureHelper();
            this.context = context;
        }

        [Given(@"That we have a wrong user and a password")]
        public void GivenThatWeHaveAWrongUserAndAPassword()
        {
            context.Add(nameof(Credentials), new Credentials("user", "password"));
        }

        [When(@"We log request a new token")]
        public void WhenWeLogRequestANewToken()
        {
            var credentials = context.Get<Credentials>(nameof(Credentials));
            var response = tokenFeatureHelper.Login(url, credentials.User, credentials.Password);
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
