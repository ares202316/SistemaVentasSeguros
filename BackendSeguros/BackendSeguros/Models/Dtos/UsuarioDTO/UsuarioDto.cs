using System.ComponentModel.DataAnnotations;

namespace BackendSeguros.Models.Dtos.UsuarioDTO
{
    public class UsuarioDto
    {

        
        public int id { get; set; }
        
        public string usuario { get; set; }

        public string Nombre { get; set; }

        public string password { get; set; }


        public enum TipoRol
        {
            Administrador,
            Cliente
        }

        public TipoRol Rol { get; set; }

        public DateTime FecRegistro { get; set; }
    }
}
