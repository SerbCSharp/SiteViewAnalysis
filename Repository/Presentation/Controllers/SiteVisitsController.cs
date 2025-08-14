using Microsoft.AspNetCore.Mvc;
using Repository.Presentation.Dto.Request;

namespace Repository.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SiteVisitsController : ControllerBase
    {
        private readonly ILogger<SiteVisitsController> _logger;

        public SiteVisitsController(ILogger<SiteVisitsController> logger)
        {
            _logger = logger;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create (Visit visit)
        {
            return Ok(visit);
        }

        [HttpPost("ReadAll")]
        public async Task<IActionResult> ReadAll()
        {
            return Ok();
        }
    }
}
