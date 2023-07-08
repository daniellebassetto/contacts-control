using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace ContactsControl.Models
{
    public class ContactModel
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Nome não pode ser vazio")]
        [StringLength(50)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "E-mail não pode ser vazio")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [StringLength(256)]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Telefone não pode ser vazio")]
        [Phone(ErrorMessage = "Telefone inválido")]
        [StringLength(18)]
        public string Phone { get; set; }
    }
}