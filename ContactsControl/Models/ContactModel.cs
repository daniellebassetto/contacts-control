using System.ComponentModel.DataAnnotations;

namespace ContactsControl.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome não pode ser vazio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "E-mail não pode ser vazio")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefone não pode ser vazio")]
        [Phone(ErrorMessage = "Telefone inválido")]
        public string Phone { get; set; }
    }
}