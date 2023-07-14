using ContactsControl.Models;

namespace ContactsControl.Repositories
{
    public interface IUserRepository
    {
        UserModel Create(UserModel User);
        bool Delete(long id);
        UserModel Get(long id);
        List<UserModel> GetAll();
        UserModel GetLogin(string login);
        UserModel GetLoginAndEmail(string login, string email);
        UserModel RedefinePassword(RedefinePasswordModel redefinePasswordModel);
        UserModel Update(UserModel User);
    }
}