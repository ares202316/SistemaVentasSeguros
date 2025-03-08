using BackendSeguros.Data;
using BackendSeguros.Models;
using BackendSeguros.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;

namespace BackendSeguros.Repositorio
{
    public class CorredorRepository : ICorredorRepositorio
    {

        private readonly ApplicationDbContext _bd;

        public CorredorRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public bool ActualizarCorredor(Corredor Corredor)
        {
            Corredor.FecRegistro = DateTime.Now;
            _bd.Corredor.Update(Corredor);
            return Guardar();
        }

        public bool BorrarCorredor(Corredor Corredor)
        {
            _bd.Corredor.Remove(Corredor);
            return Guardar();
        }

        public ICollection<Corredor> BuscarCorredor(string NomCorredor)
        {
            IQueryable<Corredor> query = _bd.Corredor;
            if (!string.IsNullOrEmpty(NomCorredor))
            {
                query = query.Where(e => e.Nombre.Contains(NomCorredor) || e.Apellido.Contains(NomCorredor) || e.Dni.Contains(NomCorredor) || e.CodCorredor.Contains(NomCorredor));
            }

            return query.ToList();
        }

        public bool CrearCorredor(Corredor Corredor)
        {
            var ultimoCodigoStr = _bd.Corredor
                .OrderByDescending(c => c.CodCorredor)
                .Select(c => c.CodCorredor)
                .FirstOrDefault();

            int ultimoCodigo = 700000;

            if (!string.IsNullOrEmpty(ultimoCodigoStr))
            {
                int.TryParse(ultimoCodigoStr, out ultimoCodigo);
            }

            int nuevoCodigo = ultimoCodigo + 1;
            Corredor.CodCorredor = nuevoCodigo.ToString();

            Corredor.FecRegistro = DateTime.Now;
            _bd.Corredor.Add(Corredor);
            return Guardar();
        }

        public bool ExisteCodCorredor(string codigoCorredor)
        {
            bool valor = _bd.Corredor.Any(c => c.CodCorredor.ToLower().Trim() == codigoCorredor.ToLower().Trim());
            return valor;
        }

        public bool ExisteCorredor(int idCorredor)
        {
            bool valor = _bd.Corredor.Any(C => C.id == idCorredor);
            return valor;
        }

        public bool ExisteDniCorredor(string DniCorredor)
        {
            bool valor = _bd.Corredor.Any(c => c.Dni.ToLower().Trim() == DniCorredor.ToLower().Trim());
            return valor;
        }

        public bool ExisteEmailCorredor(string correoCorredor)
        {
            bool valor = _bd.Corredor.Any(c => c.Email.ToLower().Trim() == correoCorredor.ToLower().Trim());
            return valor;
        }

        public Corredor GetCorredor(int idCorredor)
        {
            return _bd.Corredor.FirstOrDefault(r => r.id == idCorredor);
        }

        public IList<Corredor> GetCorredores()
        {
            return _bd.Corredor.OrderBy(c => c.CodCorredor).ToList();
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
