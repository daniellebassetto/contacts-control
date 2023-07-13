using ContactsControl.Models;

namespace ContactsControl.Helpers
{
    public interface ISession
    {
        void CreateUserSession(UserModel user);
        void RemoveUserSession();
        UserModel GetUserSession();
    }
}