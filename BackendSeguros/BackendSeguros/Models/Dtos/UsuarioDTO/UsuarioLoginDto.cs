using System.ComponentModel.DataAnnotations;

namespace BackendSeguros.Models.Dtos.UsuarioDTO
{
    public class UsuarioLoginDto
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string usuario { get; set; }

        [Required(ErrorMessage = "El password es obligatorio")]
        public string password { get; set; }
    }
}
