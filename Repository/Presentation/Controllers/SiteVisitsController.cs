using Microsoft.AspNetCore.Mvc;
using Repository.Application.Services;
using Repository.Domain.VisitAggregate;
using Repository.Presentation.Dto.Request;

namespace Repository.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SiteVisitsController : ControllerBase
    {
        private readonly ILogger<SiteVisitsController> _logger;
        private readonly SiteVisitsService _siteVisitsService;
        public SiteVisitsController(SiteVisitsService siteVisitsService, ILogger<SiteVisitsController> logger)
        {
            _siteVisitsService = siteVisitsService;
            _logger = logger;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create (VisitDto visit)
        {
            var visitDomain = new Visit { IpAddress = visit.IpAddress, Url = visit.Url, Created = DateTime.UtcNow };
            var result = await _siteVisitsService.CreateAsync(visitDomain);
            return Ok(result);
        }

        [HttpGet("ReadAll")]
        public async Task<IActionResult> ReadAll()
        {
            var result = await _siteVisitsService.ReadAllAsync();
            return Ok(result);
        }
    }
}
