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
            User.SetHashPassword();
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

        public UserModel GetLogin(string login)
        {
            return _dataBaseContext.User.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public UserModel GetLoginAndEmail(string login, string email)
        {
            return _dataBaseContext.User.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper() && x.Email.ToUpper() == email.ToUpper());
        }

        public UserModel RedefinePassword(RedefinePasswordModel redefinePasswordModel)
        {
            UserModel userModel = Get(redefinePasswordModel.UserId) ?? throw new Exception("Houve um erro na atualização da senha, usuário não encontrado");

            if (!userModel.IsValidPassword(redefinePasswordModel.CurrentPassword))
                throw new Exception("Senha atual incorreta");

            if (userModel.IsValidPassword(redefinePasswordModel.NewPassword))
                throw new Exception("Nova senha deve ser diferente da senha atual");

            userModel.SetNewPassword(redefinePasswordModel.NewPassword);
            userModel.ChangeDate = DateTime.Now;

            _dataBaseContext.User.Update(userModel);
            _dataBaseContext.SaveChanges();

            return userModel;
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