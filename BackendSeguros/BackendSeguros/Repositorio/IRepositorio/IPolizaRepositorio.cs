using BackendSeguros.Models;
using BackendSeguros.Models.Dtos.PolizaDTO;

namespace BackendSeguros.Repositorio.IRepositorio
{
    public interface IPolizaRepositorio
    {

        IList<PolizaDatosGeneralDto> GetPolizas(int pageNumber, int pageSize);
        int GetTotalPolizas();
       
        Poliza GetPoliza(int idPoliza);
        bool CrearPoliza(Poliza poliza);

        bool ActualizarPoliza(Poliza poliza);

        bool ExistePoliza(int idPoliza);


        bool BorrarPoliza(Poliza poliza);
        
        bool Guardar();

        

        ICollection<Poliza> GetPolizaenClientes(string clientes);
        ICollection<Poliza> GetPolizaenCorredor(string corredor);

        ICollection<Poliza> GetPolizaenRamo(string ramo);


    }
}
