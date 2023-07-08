using ContactsControl.Enums;

namespace ContactsControl.Models.User
{
    public class UserModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public TypeProfile Profile { get; set; }
        public string Senha { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}