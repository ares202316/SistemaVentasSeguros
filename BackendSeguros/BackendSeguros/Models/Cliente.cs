using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendSeguros.Models
{
    public class Cliente
    {

        [Key]
        public int id { get; set; }


        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre del Cliente")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [Display(Name = "Apellido del Cliente")]
        public string Apellido { get; set; }

        
        [StringLength(13, MinimumLength = 13, ErrorMessage = "El DNI debe tener exactamente 13 dígitos")]
        [RegularExpression("^[0-9]{8}$", ErrorMessage = "El DNI solo debe contener números")]
        public string Dni { get; set; }

        [Required(ErrorMessage = "El RTN es obligatorio")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "El RTN debe tener exactamente 13 dígitos")]
        [RegularExpression("^[0-9]{8}$", ErrorMessage = "El RTN solo debe contener números")]
        public string Rtn { get; set; }

        

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateOnly FecNacimiento { get; set; 
        }

        public enum TipoPersonaEnum
        {
            Natural,
            Juridico
        }

        [Required(ErrorMessage = "Debe seleecionar alguno")]
        public TipoPersonaEnum TipoPersona { get; set; }

        [Required(ErrorMessage = "El celular es obligatorio")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "El celular debe tener exactamente 8 dígitos")]
        [RegularExpression("^[0-9]{8}$", ErrorMessage = "El celular solo debe contener números")]
        public string celular { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "El teléfono debe tener exactamente 8 dígitos")]
        [RegularExpression("^[0-9]{8}$", ErrorMessage = "El teléfono solo debe contener números")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El Correo es obligatorio")]
        public  string Email { get; set; }


        [MaxLength(100)]
        [Required(ErrorMessage = "La direccion es obligatoria")]
        public string Direccion { get; set; }

        public DateTime FecRegistro { get; set; }

        }
    }

