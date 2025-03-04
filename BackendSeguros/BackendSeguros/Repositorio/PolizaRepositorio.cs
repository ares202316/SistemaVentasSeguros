﻿using BackendSeguros.Data;
using BackendSeguros.Models;
using BackendSeguros.Models.Dtos.PolizaDTO;
using BackendSeguros.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;

namespace BackendSeguros.Repositorio
{
    public class PolizaRepositorio : IPolizaRepositorio


    {


        private readonly ApplicationDbContext _bd;

        public PolizaRepositorio(ApplicationDbContext bd)
        {
            _bd = bd;
        }


        public bool ActualizarPoliza(Poliza poliza)
        {
            poliza.montoNeto = poliza.montoAsegurar * 0.02m; // 2% del montoAsegurar
            poliza.comision = poliza.montoNeto * 0.10m;      // 10% del montoNeto
            poliza.impuesto = poliza.montoNeto * 0.18m;      // 18% del montoNeto
            poliza.prima = poliza.montoNeto + poliza.impuesto; // Suma montoNeto + impuesto
            poliza.totalPagar = poliza.prima + poliza.comision; // Suma prima + comisión
            poliza.cuota = poliza.totalPagar / 12;
            poliza.FecRegistro = DateTime.Now;
            _bd.Poliza.Update(poliza);
            return Guardar();

        }

        public bool BorrarPoliza(Poliza poliza)
        {
            _bd.Poliza.Remove(poliza);
            return Guardar();
        }

        public ICollection<Poliza> BuscarPoliza(string codigo)
        {
            IQueryable<Poliza> query = _bd.Poliza;
            if (!string.IsNullOrEmpty(codigo))
            {
                query = query.Where(e => e.codigo.Contains(codigo));
            }

            return query.ToList();
        }

        public bool CrearPoliza(Poliza poliza)
        {
            poliza.FecRegistro = DateTime.Now;

            var ultimaPoliza = _bd.Poliza.OrderByDescending(p => p.id).FirstOrDefault();

            if (ultimaPoliza != null)
            {
                poliza.codigo = (int.Parse(ultimaPoliza.codigo) + 1).ToString();
            }
            else
            {
                poliza.codigo = "100000"; 
            }

            poliza.montoNeto = poliza.montoAsegurar * 0.02m; // 2% del montoAsegurar
            poliza.comision = poliza.montoNeto * 0.10m;      // 10% del montoNeto
            poliza.impuesto = poliza.montoNeto * 0.18m;      // 18% del montoNeto
            poliza.prima = poliza.montoNeto + poliza.impuesto; // Suma montoNeto + impuesto
            poliza.totalPagar = poliza.prima + poliza.comision; // Suma prima + comisión
            poliza.cuota = poliza.totalPagar / 12;           

            _bd.Poliza.Add(poliza);
            return Guardar();
        }

        public bool ExistePoliza(string codigo)
        {
            bool valor = _bd.Poliza.Any(c => c.codigo.ToLower().Trim() == codigo.ToLower().Trim());
            return valor;
        }

        public Poliza GetPoliza(int idPoliza)
        {
            return _bd.Poliza.FirstOrDefault(r => r.id == idPoliza);
        }

        public ICollection<Poliza> GetPolizaenClientes(string clientes)
        {
            return _bd.Poliza
              .Include(ci => ci.Corredor)
              .Where(ci => ci.Cliente.Dni.ToLower().Trim() == clientes.ToLower().Trim())
              .ToList();
        }

        public ICollection<Poliza> GetPolizaenCorredor(string corredor)
        {
            return _bd.Poliza
              .Include(co => co.Corredor)
              .Where(co => co.Corredor.Dni.ToLower().Trim() == corredor.ToLower().Trim())
              .ToList();
        }

        public ICollection<Poliza> GetPolizaenRamo(string ramo)
        {
            return _bd.Poliza
               .Include(ra => ra.Ramo)
               .Where(ra => ra.Ramo.NombreRamos.ToLower().Trim() == ramo.ToLower().Trim())
               .ToList();
        }

        public IList<PolizaDatosGeneralDto> GetPolizas(int pageNumber, int pageSize)
        {
            var polizas = _bd.Poliza
            .Include(p => p.Cliente)  
            .Include(p => p.Corredor) 
            .Include(p => p.Ramo)     
            .OrderBy(p => p.codigo)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
            return polizas.Select(p => new PolizaDatosGeneralDto
            {
                id = p.id,
                Codigo = p.codigo,
                ClienteDni = p.Cliente.Dni,
                ClienteNombre = p.Cliente.Nombre + " " + p.Cliente.Apellido,
                Corredorcodigo = p.codigo,
                CorredorNombre = p.Corredor.Nombre + " " + p.Cliente.Apellido, 
                RamoNombre = p.Ramo.NombreRamos,         
                MontoAsegurar = p.montoAsegurar,
                MontoNeto = p.montoNeto,
                Comision = p.comision,
                Impuesto = p.impuesto,
                TotalPagar = p.totalPagar,
                Prima = p.prima,
                Cuota = p.cuota,
                FecRegistro = p.FecRegistro

            }).ToList();
        }

        public int GetTotalPolizas()
        {
            return _bd.Poliza.Count();
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
