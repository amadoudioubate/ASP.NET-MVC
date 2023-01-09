using _01_Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _01_Controllers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IConfiguration _configuration;

        // Injection de dépendance par le constructeur de '_logger' et '_configuration' => j'aurais accès aux méthodes de Ilogger et Iconfiguration
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger; // _logger récupèré par injection de dépendance, l'importance ID je n'ai pas à instacier l'objet logger dans mon controleur (on ne se souci pas de la recompilation)
            _configuration = configuration;
        }

        // Dans un controller, les méthodes sont appelées des actions
        // --------
        public IActionResult Index()
        {
            _logger.LogTrace("Trace log from Action Privacy");
            _logger.LogDebug("Debug log from Action Privacy");
            _logger.LogInformation("Info log from Action Privacy");
            _logger.LogWarning("Warning log from Action Privacy");
            _logger.LogError("Error log from Action Privacy");
            _logger.LogCritical("Critical log from Action Privacy");
            // return View();
            return View("Index", _configuration.GetValue<string>("testSettings")); // Récupère ici par injection de dépendance 'testSettings' dans 'appsettings.json'
        }

        public IActionResult Privacy()
        {

            _logger.LogTrace("Trace log");
            _logger.LogDebug("Debug log");
            _logger.LogInformation("Info log");
            _logger.LogWarning("Warning log");
            _logger.LogError("Error log");
            _logger.LogCritical("Critical log");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}