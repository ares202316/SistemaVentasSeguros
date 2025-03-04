using System.ComponentModel.DataAnnotations;

namespace BackendSeguros.Models.Dtos.UsuarioDTO
{
    public class CreaRUsuarioDto
    {

        
        
        [Required(ErrorMessage = "El Nombre es de caracter obligatorio")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "El usuario es de caracter obligatorio")]
        public string usuario { get; set; }
        [Required(ErrorMessage = "El password es de caracter obligatorio")]
        public string password { get; set; }


        public enum TipoRol
        {
            Administrador,
            Cliente
        }

        [Required(ErrorMessage = "Debe seleecionar el rol")]
        public TipoRol Rol { get; set; }

        
    }
}
