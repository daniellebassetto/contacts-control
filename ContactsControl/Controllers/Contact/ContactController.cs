using ContactsControl.Filters;
using ContactsControl.Models;
using ContactsControl.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ContactsControl.Controllers
{
    [LoggedUserPage]
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        private readonly Helpers.ISession _session;
        public ContactController(IContactRepository contactRepository, Helpers.ISession session)
        {
            _contactRepository = contactRepository;
            _session = session;
        }

        public IActionResult Index()
        {            
            List<ContactModel> contatos = _contactRepository.GetAll(_session.GetUserSession().Id);
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
            try
            {
                bool excluded = _contactRepository.Delete(id);

                if (excluded)
                {
                    TempData["SuccessMessage"] = "Contato excluído com sucesso";
                }
                else
                {
                    TempData["ErrorMessage"] = $"Erro: não foi possível apagar este contato";
                }
                
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erro: {ex.Message}";
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contact.UserId = _session.GetUserSession().Id;
                    _contactRepository.Create(contact);
                    TempData["SuccessMessage"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contact);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Update(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contact.UserId = _session.GetUserSession().Id;
                    _contactRepository.Update(contact);
                    TempData["SuccessMessage"] = "Contato alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contact);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}