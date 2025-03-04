using System.Linq;
using BackendSeguros.Data;
using BackendSeguros.Models;
using BackendSeguros.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;

namespace BackendSeguros.Repositorio
{
    public class CoberturaRepository : ICoberturaRepositorio
    {

        private readonly ApplicationDbContext _bd;

        public CoberturaRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }


        public bool ActualizarCobertura(Cobertura cobertura)
        {
            cobertura.FecRegistro = DateTime.Now;
            _bd.Cobertura.Update(cobertura);
            return Guardar();
        }

        public bool BorrarCobertura(Cobertura cobertura)
        {
            _bd.Cobertura.Remove(cobertura);
            return Guardar();
        }

        public ICollection<Cobertura> BuscarCobertura(string NomCobertura)
        {
            IQueryable<Cobertura> query = _bd.Cobertura;
            if (!string.IsNullOrEmpty(NomCobertura))
            {
                query = query.Where(e => e.NombreCobertura.Contains(NomCobertura));
            }

            return query.ToList();
        }

        public bool CrearCobertura(Cobertura cobertura)
        {
            cobertura.FecRegistro = DateTime.Now;
            _bd.Cobertura.Add(cobertura);
            return Guardar();
        }

        public bool ExisteCobertura(string NomCobertura)
        {
            bool valor = _bd.Cobertura.Any(c => c.NombreCobertura.ToLower().Trim() == NomCobertura.ToLower().Trim());
            return valor;
        }

        public bool ExisteCobertura(int idCobertura)
        {
            bool valor = _bd.Cobertura.Any(C => C.id == idCobertura);
            return valor;
        }

        public Cobertura GetCobertura(int idCobertura)
        {
            return _bd.Cobertura.FirstOrDefault(r => r.id == idCobertura);
        }

        public ICollection<Cobertura> GetCoberturaEnRamos(string NombRamo)
        {
            return _bd.Cobertura
                .Include(ca => ca.Ramo)
                .Where(ca => ca.Ramo.NombreRamos.ToLower().Trim() == NombRamo.ToLower().Trim())
                .ToList();
        }

        public IList<Cobertura> GetCoberturas()
        {
            return _bd.Cobertura.OrderBy(c => c.id).ToList();
        }

        public int? Getid(string nombreRamo)
        {
            // Buscar el ramo por nombre y devolver solo el ID
            var ramo = _bd.Ramo.FirstOrDefault(r => r.NombreRamos.ToLower().Trim() == nombreRamo.ToLower().Trim());

            // Si no se encuentra, devolvemos null
            return ramo?.id;
        }

        public bool Guardar()
        {
            try
            {
                return _bd.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                // Aquí puedes loggear el error o manejarlo como prefieras
                Console.WriteLine($"Error al guardar: {ex.Message}");
                return false;
            }
        }

    }
}
