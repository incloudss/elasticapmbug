namespace OpenTelemetryTest
{
    public interface ITestClient
    {
        Task TestCall();
    }

    public class TestClient : ITestClient
    {
        private readonly HttpClient _httpClient;

        public TestClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task TestCall()
        {
            var response = await _httpClient.GetAsync("http://localhost:5052/Downstream");
        }
    }
}
