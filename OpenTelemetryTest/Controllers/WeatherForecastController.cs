using Microsoft.AspNetCore.Mvc;

namespace OpenTelemetryTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UpperController : ControllerBase
    {
        private readonly ILogger<UpperController> _logger;
        private readonly ITestClient _testClient;

        public UpperController(ILogger<UpperController> logger, ITestClient testClient)
        {
            _logger = logger;
            _testClient = testClient;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            await _testClient.TestCall();
            return Ok();
        }
    }
}