using ContactsControl.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ContactsControl.Controllers.Restrict
{
    [LoggedUserPage]
    public class RestrictController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}