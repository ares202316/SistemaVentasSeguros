using BackendSeguros.Data;
using BackendSeguros.Models;
using BackendSeguros.Repositorio.IRepositorio;

namespace BackendSeguros.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {

        private readonly ApplicationDbContext _bd;

        public ClienteRepositorio(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public bool ActualizarCliente(Cliente cliente)
        {
            cliente.FecRegistro = DateTime.Now;
            _bd.Cliente.Update(cliente);
            return Guardar();
        }

        public bool BorrarCliente(Cliente cliente)
        {
            _bd.Cliente.Remove(cliente);
            return Guardar();
        }

        public ICollection<Cliente> BuscarCliente(string nombre)
        {
            IQueryable<Cliente> query = _bd.Cliente;
            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(e => e.Dni.Contains(nombre) || e.Nombre.Contains(nombre));
            }

            return query.ToList();
        }

        public bool CrearCliente(Cliente cliente)
        {
                     

            cliente.FecRegistro = DateTime.Now;
            _bd.Cliente.Add(cliente);
            return Guardar();
        }

        public bool ExisteCliente(string dni)
        {
            bool valor = _bd.Cliente.Any(c => c.Dni.ToLower().Trim() == dni.ToLower().Trim());
            return valor;
        
        }

        public bool ExisteCliente(int idCliente)
        {
            bool valor = _bd.Cliente.Any(C => C.id == idCliente);
            return valor;
        }

        public Cliente GetCliente(int idCliente)
        {
            return _bd.Cliente.FirstOrDefault(r => r.id == idCliente);
        }

        public IList<Cliente> GetClientes()
        {
            return _bd.Cliente.OrderBy(c => c.Nombre).ToList();
        }

        public bool Guardar()
        {
            try
            {
                return _bd.SaveChanges() > 0;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error al guardar: {ex.Message}");
                return false;
            }
        }
    }
}
