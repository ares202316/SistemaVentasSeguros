using BackendSeguros.Data;
using BackendSeguros.Models;
using BackendSeguros.Repositorio.IRepositorio;

namespace BackendSeguros.Repositorio
{
    public class RamoRepositorio : IRamoRepositorio
    {

        private readonly ApplicationDbContext _bd;

        public RamoRepositorio(ApplicationDbContext bd)
        {
            _bd = bd;
        }
        public bool ActualizarRamo(Ramo ramo)
        {
            ramo.FecRegistro = DateTime.Now;
            _bd.Ramo.Update(ramo);
            return Guardar();
        }

        public bool BorrarRamo(Ramo ramo)
        {
            _bd.Ramo.Remove(ramo);
            return Guardar();
        }

        public ICollection<Ramo> BuscarRamo(string NomRamo)
        {
            IQueryable<Ramo> query = _bd.Ramo;
            if (!string.IsNullOrEmpty(NomRamo))
            {
                query = query.Where(e => e.NombreRamos.Contains(NomRamo));
            }

            return query.ToList();
        }

        public bool CrearRamo(Ramo ramo)
        {
            ramo.FecRegistro = DateTime.Now;
            _bd.Ramo.Add(ramo);
            return Guardar();
        }

        public Ramo GetRamo(int idRamo)
        {
            return _bd.Ramo.FirstOrDefault(r => r.id == idRamo);
        }

        public bool ExisteRamo(string NomRamo)
        {
            bool valor = _bd.Ramo.Any(c => c.NombreRamos.ToLower().Trim() == NomRamo.ToLower().Trim());
            return valor;
        }

        public bool ExisteRamo(int idRamo)
        {
            bool valor = _bd.Ramo.Any(C => C.id == idRamo);
            return valor;
        }

        public IList<Ramo> GetRamos()
        {
            return _bd.Ramo.OrderBy(c => c.NombreRamos).ToList();
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
