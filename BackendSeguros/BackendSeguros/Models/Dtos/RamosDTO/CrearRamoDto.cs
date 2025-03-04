using System.ComponentModel.DataAnnotations;

namespace BackendSeguros.Models.Dtos.RamosDTO
{
    public class CrearRamoDto
    {



        [Required(ErrorMessage = "El nombre del ramo es obligatorio")]
        [Display(Name = "El nombre del Ramo")]
        [MaxLength(50, ErrorMessage = "El nombre del ramo no puede exceder los 50 caracteres.")]
        public string NombreRamos { get; set; }
        [MaxLength(200, ErrorMessage = "El nombre del ramo no puede exceder los 200 caracteres.")]
        public string Descripcion { get; set; }

      


    }
}
