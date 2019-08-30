using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Threading;
using TropicalTrooperTemplate.Contracts.V1;

namespace TropicalTrooperTemplate.Controllers.V1
{
    public class HomeController : Controller
    {
        static int _callCount;

        readonly ILogger<HomeController> _logger;
        readonly IDiagnosticContext _diagnosticContext;

        public HomeController(ILogger<HomeController> logger, IDiagnosticContext diagnosticContext)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _diagnosticContext = diagnosticContext ?? throw new ArgumentNullException(nameof(diagnosticContext));
        }

        [HttpGet(ApiRoutes.Posts.Get)]
        public IActionResult Get()
        {

            _logger.LogInformation("Hello, world!");

            _diagnosticContext.Set("IndexCallCount", Interlocked.Increment(ref _callCount));

            return Ok(new { name = "shotigo" });
        }
    }
}
