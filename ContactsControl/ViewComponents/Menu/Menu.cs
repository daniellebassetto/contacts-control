using ContactsControl.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ContactsControl.ViewComponents
{
    public class Menu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string userSession = HttpContext.Session.GetString("loggedUserSession");

            if (string.IsNullOrEmpty(userSession))
                return null;

            UserModel user = JsonConvert.DeserializeObject<UserModel>(userSession);

            return View(user);
        }
    }
}