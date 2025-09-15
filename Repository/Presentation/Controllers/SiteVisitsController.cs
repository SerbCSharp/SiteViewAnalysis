using Microsoft.AspNetCore.Mvc;
using Repository.Application.Services;
using Repository.Domain.VisitAggregate;
using Repository.Presentation.Dto.Request;
using Repository.Presentation.Dto.Response;

namespace Repository.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SiteVisitsController : ControllerBase
    {
        private readonly SiteVisitsService _siteVisitsService;
        public SiteVisitsController(SiteVisitsService siteVisitsService)
        {
            _siteVisitsService = siteVisitsService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create (CreateVisit visit)
        {
            var visitDomain = new Visit(visit.IpAddress, visit.Url, DateTime.UtcNow);
            await _siteVisitsService.CreateAsync(visitDomain);
            return NoContent();
        }

        [HttpGet("ReadAll")]
        public async Task<IActionResult> ReadAll()
        {
            var listVisit = await _siteVisitsService.ReadAllAsync();
            var result = listVisit.Select(x => new VisitDto(x.IpAddress, x.Url, x.Created));
            return Ok(result);
        }
    }
}
