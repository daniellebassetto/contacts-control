using ContactsControl.Models;

namespace ContactsControl.Repositories
{
    public interface IUserRepository
    {
        List<UserModel> GetAll();
        UserModel Get(long id);
        UserModel Create(UserModel User);
        UserModel Update(UserModel User);
        bool Delete(long id);
    }
}