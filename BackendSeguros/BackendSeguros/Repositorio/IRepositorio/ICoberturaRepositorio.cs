using BackendSeguros.Models;

namespace BackendSeguros.Repositorio.IRepositorio
{
    public interface ICoberturaRepositorio
    {

        IList<Cobertura> GetCoberturas();
        int? Getid(string nombre);
        bool ExisteCobertura(string NomCobertura);
        Cobertura GetCobertura(int idCobertura);
        bool ExisteCobertura(int idCobertura);
        bool CrearCobertura(Cobertura cobertura);

        bool ActualizarCobertura(Cobertura cobertura);

        bool BorrarCobertura(Cobertura cobertura);
        
        bool Guardar();

        ICollection<Cobertura> BuscarCobertura(string NomCobertura);

        ICollection<Cobertura> GetCoberturaEnRamos(string NombRamo);

    }
}
