using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace BackendSeguros.Models
{
    public class Usuario
    {

        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "El Nombre es de caracter obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage ="El usuario es de caracter obligatorio")]
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

        public DateTime FecRegistro { get; set; }
    }
}
