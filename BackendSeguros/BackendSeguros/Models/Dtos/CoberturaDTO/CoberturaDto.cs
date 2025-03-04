using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackendSeguros.Models.Dtos.CoberturaDTO
{
    public class CoberturaDto
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "El nombre de la cobertura es obligatorio")]
        [Display(Name = "El nombre del Ramo")]
        [MaxLength(50, ErrorMessage = "El nombre del ramo no puede exceder los 50 caracteres.")]
        public string NombreCobertura { get; set; }


        [ForeignKey("ramoId")]
        [Required(ErrorMessage = "No selecciono el tipo de ramo")]
        public int ramoId { get; set; }
      

        [Required(ErrorMessage = "La descripcion de la cobertura es obligatorio")]
        [MaxLength(200, ErrorMessage = "La descripcion del ramo no puede exceder los 200 caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El deducible de la cobertura es obligatorio")]
        [RegularExpression("^[0-9.,]+$", ErrorMessage = "Solo se permiten números, puntos y comas")]
        public double Deducible { get; set; }

        public DateTime FecRegistro { get; set; }

       

        //Relacion de la tabla de RAmo


    }
}
