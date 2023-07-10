using ContactsControl.Enums;
using System.ComponentModel.DataAnnotations;

namespace ContactsControl.Models
{
    public class UserUpdateModel
    {
        //This model does not have password and date validations
        public long Id { get; set; }
        [Required(ErrorMessage = "Informe o nome")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Informe o login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Informe o tipo de usuário")]
        public TypeUser? TypeUser { get; set; }
        [Required(ErrorMessage = "Informe o e-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }
    }
}