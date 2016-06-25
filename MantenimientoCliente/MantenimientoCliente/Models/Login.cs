using System.ComponentModel.DataAnnotations;

namespace MantenimientoCliente.Models
{
    public class LoginModel
    {
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "¿Recordar cuenta?")]
        public bool RememberMe { get; set; }
    }
}