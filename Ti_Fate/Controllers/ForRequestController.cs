using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ti_Fate.Controllers
{
    public class ForRequestController
    {
        private readonly ILogger<ForRequestController> _logger;

        public ForRequestController(ILogger<ForRequestController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("ForRequestController received one request.");
            return new OkResult();
        }
    }
}
