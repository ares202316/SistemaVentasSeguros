using BackendSeguros.Models;

namespace BackendSeguros.Repositorio.IRepositorio
{
    public interface IClienteRepositorio
    {

        IList<Cliente> GetClientes();
        bool ExisteCliente(string dni);
        Cliente GetCliente(int idCliente);
        bool ExisteCliente(int idCliente);
        bool CrearCliente(Cliente cliente);

        bool ActualizarCliente(Cliente cliente);

       

        bool BorrarCliente(Cliente cliente);
        
        bool Guardar();

        ICollection<Cliente> BuscarCliente(string nombre);

    }
}
