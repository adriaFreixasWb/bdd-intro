using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace IntroToBDD.Helpers
{
    public class TokenFeatureHelper
    {
        private const string MediaType = "application/json";
        private readonly Encoding ContentEncoding = Encoding.UTF8;

        private const int TOKEN_REQUEST_TYPE = 5;

        public HttpResponseMessage Login(string url, string user, string password)
        {
            var client = new HttpClient();
            var request = CreateRequest(url, user, password);
            return client.Send(request);
        }

        private HttpRequestMessage CreateRequest(string url, string user, string password)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            AddBasicAuthentication(request, user, password);
            AddRequestTokenBoyd(request);
            return request;
        }

        private void AddBasicAuthentication(HttpRequestMessage request, string user, string password)
        {
            var authenticationString = $"{user}:{password}";
            var base64String = Convert.ToBase64String(Encoding.ASCII.GetBytes(authenticationString));
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64String);
        }
        private void AddRequestTokenBoyd(HttpRequestMessage request) =>
            request.Content = new StringContent(SerilizeRequestTokenBody(), ContentEncoding, MediaType);

        public string SerilizeRequestTokenBody()=>
            JsonSerializer.Serialize(new { request = new { type = TOKEN_REQUEST_TYPE} });
    }
}
