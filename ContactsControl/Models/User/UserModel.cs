using ContactsControl.Enums;
using System.ComponentModel.DataAnnotations;

namespace ContactsControl.Models
{
    public class UserModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Nome não pode ser vazio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Login não pode ser vazio")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Senha não pode ser vazia")]
        public string Password { get; set; }
        public TypeUser Profile { get; set; }
        [Required(ErrorMessage = "E-mail não pode ser vazio")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }       
        public DateTime RegistrationDate { get; set; }
        public DateTime? ChangeDate { get; set; }
    }
}