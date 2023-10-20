namespace DownstreamService
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
            var response = await _httpClient
                .PostAsync("https://chemassets.ihs.com/ChemAssets/UnitOfMeasure/GetUnitOfMeasures?username=chemassetsConnect&password=witcher3TheB3st", null);
        }
    }
}
