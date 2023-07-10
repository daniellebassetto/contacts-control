using ContactsControl.Data;
using ContactsControl.Models;

namespace ContactsControl.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataBaseContext _dataBaseContext;

        public UserRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public UserModel Create(UserModel User)
        {
            User.RegistrationDate = DateTime.Now;
            _dataBaseContext.User.Add(User);
            _dataBaseContext.SaveChanges();
            return User;
        }

        public bool Delete(long id)
        {
            UserModel deleteUser = Get(id);

            if (deleteUser == null)
                throw new Exception("Usuário inválido ou inexistente");

            _dataBaseContext.Remove(deleteUser);
            _dataBaseContext.SaveChanges();

            return true;
        }

        public UserModel Get(long id)
        {
            return _dataBaseContext.User.FirstOrDefault(x => x.Id == id);
        }

        public List<UserModel> GetAll()
        {
            return _dataBaseContext.User.ToList();
        }

        public UserModel Update(UserModel User)
        {
            UserModel updateUser = Get(User.Id);

            if (updateUser == null)
                throw new Exception("Usuário inválido ou inexistente");

            updateUser.Name = User.Name;            
            updateUser.Login = User.Login;
            updateUser.TypeUser = User.TypeUser;
            updateUser.Email = User.Email;
            updateUser.ChangeDate = DateTime.Now;

            _dataBaseContext.Update(updateUser);
            _dataBaseContext.SaveChanges();
            return updateUser;
        }
    }
}