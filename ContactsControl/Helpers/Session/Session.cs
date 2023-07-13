using ContactsControl.Models;
using Newtonsoft.Json;

namespace ContactsControl.Helpers
{
    public class Session : ISession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Session(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void CreateUserSession(UserModel user)
        {
            string value = JsonConvert.SerializeObject(user);
            _httpContextAccessor.HttpContext.Session.SetString("loggedUserSession", value);
        }

        public UserModel GetUserSession()
        {
            string userSession = _httpContextAccessor.HttpContext.Session.GetString("loggedUserSession");

            if (string.IsNullOrEmpty(userSession))
                return null;

            return JsonConvert.DeserializeObject<UserModel>(userSession);
        }

        public void RemoveUserSession()
        {
            _httpContextAccessor.HttpContext.Session.Remove("loggedUserSession");
        }
    }
}