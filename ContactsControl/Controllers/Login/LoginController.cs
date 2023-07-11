using ContactsControl.Models;
using ContactsControl.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ContactsControl.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly Helper.ISession _session;

        public LoginController(IUserRepository userRepository, Helper.ISession session)
        {
            _userRepository = userRepository;
            _session = session;
        }

        public IActionResult Index()
        {
            // if user is logged in redirect to home
            if(_session.GetUserSession() != null) 
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public IActionResult Enter(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel user = _userRepository.GetLogin(loginModel.Login);

                    if (user != null)
                    {
                        if (user.IsValidPassword(loginModel.Password))
                        {
                            _session.CreateUserSession(user);
                            return RedirectToAction("Index", "Home");
                        }
                            

                        TempData["ErrorMessage"] = $"Senha incorreta. Tente novamente.";
                        return View("Index");
                    }

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

        public IActionResult Exit()
        {
            _session.RemoveUserSession();
            return RedirectToAction("Index", "Login");
        }
    }
}