using BackendSeguros.Models;
using BackendSeguros.Models.Dtos.PolizaDTO;

namespace BackendSeguros.Repositorio.IRepositorio
{
    public interface IPolizaRepositorio
    {

        IList<PolizaDatosGeneralDto> GetPolizas(int pageNumber, int pageSize);
        int GetTotalPolizas();
        bool ExistePoliza(string codigo);
        Poliza GetPoliza(int idPoliza);
        bool CrearPoliza(Poliza poliza);

        bool ActualizarPoliza(Poliza poliza);

       

        bool BorrarPoliza(Poliza poliza);
        
        bool Guardar();

        ICollection<Poliza> BuscarPoliza(string codigo);

        ICollection<Poliza> GetPolizaenClientes(string clientes);
        ICollection<Poliza> GetPolizaenCorredor(string corredor);

        ICollection<Poliza> GetPolizaenRamo(string ramo);


    }
}
