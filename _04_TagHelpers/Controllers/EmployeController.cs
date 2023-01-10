using _04_TagHelpers.Models;
using Microsoft.AspNetCore.Mvc;

namespace _04_TagHelpers.Controllers
{
    public class EmployeController : Controller
    {
        public IActionResult Create()
        {
            //return View(new Employe());
            return View("CreateHtmlHelper", new Employe());
        }


        public IActionResult Hello(Employe emp)
        {
            return View(emp);
        }
    }

}
