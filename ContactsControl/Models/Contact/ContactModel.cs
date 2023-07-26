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
        [MaxLength(15, ErrorMessage = "O telefone deve ter no mínimo 14 e no máximo 15 caracteres")]
        [MinLength(14, ErrorMessage = "O telefone deve ter no mínimo 14 e no máximo 15 caracteres")]
        public string Phone { get; set; }
        public long? UserId { get; set; }
        public UserModel? User { get; set; }
    }
}