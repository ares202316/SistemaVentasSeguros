using BackendSeguros.Models;

namespace BackendSeguros.Repositorio.IRepositorio
{
    public interface ICorredorRepositorio
    {

        IList<Corredor> GetCorredores();
        bool ExisteDniCorredor(string DniCorredor);

        bool ExisteCodCorredor(string codigoCorredor);

        bool ExisteEmailCorredor(string correoCorredor);
        Corredor GetCorredor(int idCorredor);
        bool ExisteCorredor(int idCorredor);
        bool CrearCorredor(Corredor Corredor);

        bool ActualizarCorredor(Corredor Corredor);

        bool BorrarCorredor(Corredor Corredor);
        
        bool Guardar();

        ICollection<Corredor> BuscarCorredor(string NomCorredor);

       

    }
}
