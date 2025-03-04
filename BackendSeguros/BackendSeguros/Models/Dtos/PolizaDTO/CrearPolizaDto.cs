using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackendSeguros.Models.Dtos.PolizaDTO
{
    public class CrearPolizaDto
    {


        

        [ForeignKey("clienteId")]
        [Required(ErrorMessage = "Seleccione el cliente")]
       
        public int clienteId { get; set; }
        

        [ForeignKey("corredorId")]
        [Required(ErrorMessage = "Seleccione el corredor")]
        public int corredorId { get; set; }
        

        [ForeignKey("ramoId")]
        [Required(ErrorMessage = "Seleccione el ramo")]
        public int ramoId { get; set; }
        

        [Required]
        private decimal _montoAsegurar;
        public decimal montoAsegurar
        {
            get { return _montoAsegurar; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("El monto a asegurar no puede ser negativo.");
                _montoAsegurar = value;
            }
        }


    }
}
