using System.ComponentModel.DataAnnotations;

namespace ContactsControl.Models
{
    public class ContactModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Informe o e-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Informe o telefone")]
        [Phone(ErrorMessage = "Telefone inválido")]
        public string Phone { get; set; }
        public long? UserId { get; set; }
        public UserModel User { get; set; }
    }
}