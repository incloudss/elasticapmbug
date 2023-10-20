using Microsoft.AspNetCore.Mvc;

namespace DownstreamService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DownstreamController : ControllerBase
    {


        private readonly ILogger<DownstreamController> _logger;
        private readonly ITestClient _testClient;

        public DownstreamController(ILogger<DownstreamController> logger, ITestClient testClient)
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