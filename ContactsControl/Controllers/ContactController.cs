using ContactsControl.Models;
using ContactsControl.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ContactsControl.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IActionResult Index()
        {
            List<ContactModel> contatos = _contactRepository.GetAll();
            return View(contatos);
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

        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            _contactRepository.Create(contact);
            return RedirectToAction("Index");
        }
    }
}