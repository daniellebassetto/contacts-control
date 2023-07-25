using ContactsControl.Models;
using ContactsControl.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ContactsControl.Controllers
{
    public class RedefinePasswordController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly Helpers.ISession _session;

        public RedefinePasswordController(IUserRepository userRepository, Helpers.ISession session)
        {
            _userRepository = userRepository;
            _session = session;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(RedefinePasswordModel redefinePasswordModel)
        {
            try
            {
                UserModel userModel = _session.GetUserSession();
                redefinePasswordModel.UserId = userModel.Id;

                if (ModelState.IsValid)
                {
                    _userRepository.RedefinePassword(redefinePasswordModel);
                    TempData["SuccessMessage"] = "Senha alterada com sucesso";
                    return View("Index", redefinePasswordModel);
                }

                return View("Index", redefinePasswordModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erro: {ex.Message}";
                return View("Index", redefinePasswordModel);
            }
        }
    }
}