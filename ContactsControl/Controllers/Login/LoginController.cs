using ContactsControl.Helpers;
using ContactsControl.Models;
using ContactsControl.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ContactsControl.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly Helpers.ISession _session;
        private readonly IEmail _email;

        public LoginController(IUserRepository userRepository, Helpers.ISession session, IEmail email)
        {
            _userRepository = userRepository;
            _session = session;
            _email = email;
        }

        public IActionResult Index()
        {
            // if user is logged in redirect to home
            if(_session.GetUserSession() != null) 
                return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult RedefinePassword()
        {
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

        [HttpPost]
        public IActionResult SendLinkToRedefinePassword(RedefinePasswordModel redefinePasswordModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel user = _userRepository.GetLoginAndEmail(redefinePasswordModel.Login, redefinePasswordModel.Email);

                    if (user != null)
                    {
                        string newPassword = user.GenerateNewPassword();                        
                        string message = $"Sua nova senha é: {newPassword}";
                        bool emailSent = _email.Send(user.Email, "Sistema de Contatos - Nova Senha", message);

                        if(emailSent)
                        {
                            _userRepository.Update(user);
                            TempData["SuccessMessage"] = $"Enviamos para seu e-mail cadastrado uma nova senha.";
                        }
                        else
                        {
                            TempData["ErrorMessage"] = $"Ocorreu um erro ao enviar o e-mail. Tente novamente.";
                        }

                        return RedirectToAction("Index", "Login");
                    }

                    TempData["ErrorMessage"] = $"Não foi possível redefinir sua senha. Verifique os dados informados.";
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