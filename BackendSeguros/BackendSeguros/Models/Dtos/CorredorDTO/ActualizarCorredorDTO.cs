using System.ComponentModel.DataAnnotations;

namespace BackendSeguros.Models.Dtos.CorredorDTO
{
    public class ActualizarCorredorDTO
    {
        [Key]
        public int id { get; set; }


        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre del Cliente")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [Display(Name = "Apellido del Cliente")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El DNI es obligatorio")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "El DNI debe tener exactamente 13 dígitos")]
        [RegularExpression("^[0-9]{13}$", ErrorMessage = "El DNI solo debe contener números")]
        public string Dni { get; set; }

        [Required(ErrorMessage = "El celular es obligatorio")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "El celular debe tener exactamente 8 dígitos")]
        [RegularExpression("^[0-9]{8}$", ErrorMessage = "El celular solo debe contener números")]
        public string celular { get; set; }

        [Required(ErrorMessage = "El Correo es obligatorio")]
        public string Email { get; set; }

        public DateTime FecRegistro { get; set; }



    }
}
