using ContactsControl.Models;

namespace ContactsControl.Helper
{
    public interface ISession
    {
        void CreateUserSession(UserModel user);
        void RemoveUserSession();
        UserModel GetUserSession();
    }
}