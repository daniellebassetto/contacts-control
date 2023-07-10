using ContactsControl.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactsControl.Controllers.Login
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Enter(LoginModel login)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if(login.Login == "adm" && login.Password == "123")
                        return RedirectToAction("Index", "Home");

                    TempData["ErrorMessage"] = $"Usuário e/ou senha inválido(s). Tente novamente.";
                }

                return View("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}