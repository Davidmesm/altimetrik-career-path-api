using Microsoft.AspNetCore.Mvc;

namespace CareerPathCore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : Controller
    {
        private readonly ILogger<HealthController> _logger;

        public HealthController(ILogger<HealthController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return Ok("Working");
        }
    }
}