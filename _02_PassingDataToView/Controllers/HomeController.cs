using _02_PassingDataToView.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;

namespace _02_PassingDataToView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // après être passé par la vue 'privacy' sans y avoir été lue, on peut récupérer la donnée stockée dans un TempData
            if (TempData.ContainsKey("tempDataFromAction"))
            {
                ViewBag.tempDataFromAction = TempData["tempDataFromAction"]?.ToString();
            }

            // On récupère les données passé depuis la vue 'privacy' via un TempData
            if (TempData.ContainsKey("tempDataFromView"))
            {
                ViewBag.tempDataFromView = TempData["tempDataFromView"]?.ToString();
            }
            // Récupération d'un cookie depuis la requête
            ViewBag.myCookie = Request.Cookies["key"];

            // -- Création d'un cookie
            CookieOptions options = new()
            {
                Expires = DateTime.Now.AddSeconds(10)
            };

            Response.Cookies.Append("key", "cookie miam miam", options);


            Personnage p = new Personnage("Riri", "Duck");
            
            // La vue 'Index' prend en paramètre un objet fortement typé de type Personnage
            return View(p);
        }

        public IActionResult Privacy()
        {
            /*
             * ViewBag permet de transmettre des données au controllleur à la vue
             * ces données sont transmises en tant que propriétés de l'objet ViewBag
             * La portée du ViewBag est limités à la requête actuelle : sa valeur est réinitialisée à null une fois transmis à la vue
             */
            ViewBag.Message = "your apprlication privacy from Viewbag";


            /*
             * ViewData est un objet de type dictionnaire permettant de transmettre des données du controleur à la vue
             * ces données sont transmises sous forme de paires de clé/valeur
             *  La portée du Viewdata est limités à la requête actuelle : sa valeur est réinitialisée à null une fois transmis à la vue
             */
            ViewData["cle"] = "your application privacy from ViewData";


            IList<string> list = new List<string>
            {
                "rir",
                "fifi",
                "loulou"
            };

            ViewData["stringlist"] = list;

            // Attention ViewBag.Message <=> ViewData["Message"]
            // Une propriété du ViewBag est reconnue en tant que clé du ViewData et réciproquement


            /*
             * TempData peut être utilisé pour transférer des données :
             * - d'une vue à un controleur
             * - d'un controleur à une vue
             * - d'une 
             */
            TempData["tempDataFromAction"] = "Data from Action 'privacy' in 'HomeController' with TempData";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}