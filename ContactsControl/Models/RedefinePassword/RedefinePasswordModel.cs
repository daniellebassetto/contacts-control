using System.ComponentModel.DataAnnotations;

namespace ContactsControl.Models
{
    public class RedefinePasswordModel
    {
        public long UserId { get; set; }
        [Required(ErrorMessage = "Informe a senha atual")]
        public string CurrentPassword { get; set; }
        [Required(ErrorMessage = "Informe a nova senha")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Confirme a nova senha")]
        [Compare("NewPassword", ErrorMessage = "Senha incorreta")]
        public string ConfirmNewPassword { get; set; }
    }
}