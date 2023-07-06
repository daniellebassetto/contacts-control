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

        public IActionResult Update(int id)
        {
            ContactModel contato = _contactRepository.Get(id);
            return View(contato);
        }

        public IActionResult DeleteConfimation(int id)
        {
            ContactModel contato = _contactRepository.Get(id);
            return View(contato);
        }
        
        public IActionResult Delete(int id)
        {
            _contactRepository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            _contactRepository.Create(contact);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(ContactModel contact)
        {
            _contactRepository.Update(contact);
            return RedirectToAction("Index");
        }
    }
}