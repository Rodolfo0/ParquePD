using System.ComponentModel.DataAnnotations;

namespace ParqueProcesoDesarrollo.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo Eléctronico")]
        public string Email { get; set; }

        [Required]
        [MinLength(5)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Recuerdame")]
        public bool RememberMe { get; set; }
    }
}
