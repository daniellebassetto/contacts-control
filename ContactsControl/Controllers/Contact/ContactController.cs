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