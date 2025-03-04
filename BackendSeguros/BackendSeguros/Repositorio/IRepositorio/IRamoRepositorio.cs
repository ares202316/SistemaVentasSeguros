using BackendSeguros.Models;

namespace BackendSeguros.Repositorio.IRepositorio
{
    public interface IRamoRepositorio
    {

        IList<Ramo> GetRamos();
        bool ExisteRamo(string NomRamo);
        Ramo GetRamo(int idRamo);
        bool ExisteRamo(int idRamo);
        bool CrearRamo(Ramo ramo);

        bool ActualizarRamo(Ramo ramo);

       

        bool BorrarRamo(Ramo ramo);
        
        bool Guardar();

        ICollection<Ramo> BuscarRamo(string NomRamo);

    }
}
