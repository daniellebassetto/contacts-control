using ContactsControl.Filters;
using ContactsControl.Models;
using ContactsControl.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ContactsControl.Controllers
{
    [LoggedUserPage]
    public class HomeController : Controller
    {
        private readonly IContactRepository _contactRepository;
        private readonly Helpers.ISession _session;

        public HomeController(IContactRepository contactRepository, Helpers.ISession session)
        {
            _contactRepository = contactRepository;
            _session = session;
        }

        public IActionResult Index()
        {
            int totalContacts = _contactRepository.GetAll(_session.GetUserSession().Id).Count();
            return View(totalContacts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}