using Microsoft.AspNetCore.Mvc;
using ContactsControl.Models;
using ContactsControl.Repositories;

namespace ContactControl.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _UserRepository;
        public UserController(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public IActionResult Index()
        {
            List<UserModel> contatos = _UserRepository.GetAll();
            return View(contatos);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update(int id)
        {
            UserModel contato = _UserRepository.Get(id);
            return View(contato);
        }

        public IActionResult DeleteConfimation(int id)
        {
            UserModel contato = _UserRepository.Get(id);
            return View(contato);
        }

        public IActionResult Delete(int id)
        {

            try
            {
                bool excluded = _UserRepository.Delete(id);

                if (excluded)
                {
                    TempData["SuccessMessage"] = "Usuário excluído com sucesso";
                }
                else
                {
                    TempData["ErrorMessage"] = $"Erro: não foi possível apagar este usuário";
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
        public IActionResult Create(UserModel User)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _UserRepository.Create(User);
                    TempData["SuccessMessage"] = "Usuário cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(User);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Update(UserModel User)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _UserRepository.Update(User);
                    TempData["SuccessMessage"] = "Usuário alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(User);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}