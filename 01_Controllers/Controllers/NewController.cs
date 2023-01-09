using Microsoft.AspNetCore.Mvc;

namespace _01_Controllers.Controllers
{
    //[Route("new_route")]
    public class NewController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        // Je vais récuperer IWebHostEnvironment par Injection de dépendance avec un constructeur
        public NewController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        /*
        public IActionResult ActionReturnView()
        {
            return View(); // Retourne une vue qui porte le même nom que l'action courante dans le controller courant
        }
        */

        // /new_route/new_action
        // /new/actionReturnstring
        // /new/actionReturnstring/2
        // /new/actionReturnstring/2?firstname=riri&lastname=duck
        //[Route("new_action/{id?}")] // /new_route/new_action // Je peux le faire directement au niveau du controller
        public string ActionReturnString(int? id)
        {
            string fisrt = HttpContext.Request.Query["firstname"].ToString();
            string last = HttpContext.Request.Query["lastname"].ToString();

            return $"Hello from Action 'ActionReturnString' of Controller 'new' with query string lastname = {last} and firstname = {fisrt} and id={id}";
        }


        // /new/ActionReturnView
        public ViewResult ActionReturnView() 
        { 
            return View(); // Retourne une vue qui porte le même nom que l'action courante dans le controller courant
        }

        // /new/ActionReturnSpecificView
        public ViewResult ActionReturnSpecificView()
        {
            return View("SpecificView"); // Retourne une vue qui porte le nom 'SpecificView' que l'action courante dans le controller courant
        }

        // /new/actionReturnredirectToAction
        public ActionResult ActionReturnRedirectToAction()
        {
            return RedirectToAction("ActionReturnString");
        }

        // /new/actionReturnredirectToActionwithparameters
        public ActionResult ActionReturnRedirectToActionWithParameters()
        {
            return RedirectToAction("ActionReturnString", new {id=99, fistname="loulou"});
        }

        // /new/ActionReturnRedirectToRoute
        public ActionResult ActionReturnRedirectToRoute()
        {
            return RedirectToRoute(new {  controller = "home", action = "privacy" });
        }

        // /new/ActionReturnJson
        public ActionResult ActionReturnJson()
        {
            return Json("{key:value, key2:{key2: value3}");
        }

        // /new/ActionReturnContent (return (html))
        public ActionResult ActionReturnContent()
        {
            return Content("<div>Contenu de mon content actionReturnContent</div>", "text/html");
        }

        // /new/ActionReturnJavascript (return javascript)
        public ActionResult ActionReturnJavascript()
        {
            return Content("<script>alert(\"return javascript\")</script>", "text/html");
        }

        // /new/ActionReturnStatusCode (return code status)
        public ActionResult ActionReturnStatusCode()
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Mauvaise requête");
        }


        // /new/ActionReturnFile (cette action return (télécharge) le site.css)
        public FileResult ActionReturnFile()
        {
            string fileName = "site.css";

            // _webHostEnvironment injecté via constructeur
            string webRootPath = Path.Combine(_webHostEnvironment.WebRootPath, "css/");

            string path = webRootPath + fileName;

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", fileName);
        }


        // /new/ActionReturnFileAsync
        /*public async  Task<FileResult> ActionReturnFileAsync()
        {
            string fileName = "site.css";

            // _webHostEnvironment injecté via constructeur
            string webRootPath = Path.Combine(_webHostEnvironment.WebRootPath, "css/");

            string path = webRootPath + fileName;

            byte[] bytes = await System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", fileName);
        }*/
    }
}
