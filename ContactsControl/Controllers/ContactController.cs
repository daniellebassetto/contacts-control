using Microsoft.AspNetCore.Mvc;

namespace ContactsControl.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult DeleteConfimation()
        {
            return View();
        }
        
        public IActionResult Delete()
        {
            return View();
        }
    }
}