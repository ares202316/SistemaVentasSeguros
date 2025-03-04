namespace BackendSeguros.Models.Dtos.PolizaDTO
{
    public class PolizaDatosGeneralDto
    {
        public int id { get; set; }
        public string Codigo { get; set; }

        public string ClienteDni { get; set; }
        public string ClienteNombre { get; set; }

        public string Corredorcodigo { get; set; }
        public string CorredorNombre { get; set; }
        public string RamoNombre { get; set; }
        public decimal MontoAsegurar { get; set; }
        public decimal MontoNeto { get; set; }
        public decimal Comision { get; set; }
        public decimal Impuesto { get; set; }
        public decimal TotalPagar { get; set; }
        public decimal Prima { get; set; }
        public decimal Cuota { get; set; }
        public DateTime FecRegistro { get; set; }


    }
}
