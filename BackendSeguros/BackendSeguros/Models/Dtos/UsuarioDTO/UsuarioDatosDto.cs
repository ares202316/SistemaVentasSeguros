using System.ComponentModel.DataAnnotations;

namespace BackendSeguros.Models.Dtos.UsuarioDTO
{
    public class UsuarioDatosDto
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string usuario { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El password es obligatorio")]
        public string password { get; set; }
        public string Rol { get; set; }
    }
}
