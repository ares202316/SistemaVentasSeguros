using AutoMapper;
using BackendSeguros.Models;
using BackendSeguros.Models.Dtos.CoberturaDTO;
using BackendSeguros.Models.Dtos.RamosDTO;
using BackendSeguros.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendSeguros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class CoberturaController : ControllerBase
    {

        private readonly ICoberturaRepositorio _cobRep;
        private readonly IMapper _mapper;

        public CoberturaController(ICoberturaRepositorio cobRep, IMapper mapper)
        {
            _cobRep = cobRep;
            _mapper = mapper;
        }

        [HttpGet]
        //Agregar las respuestas
        public IActionResult GetCoberturas()
        {
            var listadeCobertura = _cobRep.GetCoberturas();
            var listaCoberturaDto = new List<CoberturaDto>();

            foreach (var lista in listadeCobertura)
            {
                listaCoberturaDto.Add(_mapper.Map<CoberturaDto>(lista));
            }

            return Ok(listaCoberturaDto);
        }

        
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CoberturaDto))]
        //Agregar las respuestas

        public IActionResult CrearCobertura([FromBody] CrearCoberturaDto crearCoberturaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (crearCoberturaDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_cobRep.ExisteCobertura(crearCoberturaDto.NombreCobertura))
            {
                ModelState.AddModelError("", "El tipo de cobertura  ya existe");
                return StatusCode(404, ModelState);
            }

            var cobertura = _mapper.Map<Cobertura>(crearCoberturaDto);

            if (!_cobRep.CrearCobertura(cobertura))
            {
                ModelState.AddModelError("", $"Algo salio mal al guardar el registro{cobertura.NombreCobertura}");
                return StatusCode(500, ModelState);
            }


            return new ObjectResult(cobertura) { StatusCode = 201 };
        }

        [HttpPatch("{coberturaId:int}", Name = "ActualizarCobertura")]
        //Agregar las respuestas

        public IActionResult ActualizarCobertura(int coberturaId, [FromBody] CoberturaDto coberturaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

         
            var cobertura = _mapper.Map<Cobertura>(coberturaDto);
            if (!_cobRep.ActualizarCobertura(cobertura))
            {
                ModelState.AddModelError("", $"Hubo un error inesperado al actualizar registro{cobertura.NombreCobertura}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpGet("{ramoid:int}", Name = "GetCobertura")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCobertura(int ramoid)
        {
            var itemCobertura = _cobRep.GetCobertura(ramoid);

            if (itemCobertura == null)
            {
                return NotFound();
            }

            var itemCoberturas = _mapper.Map<CoberturaDto>(itemCobertura);

            return Ok(itemCoberturas);
        }



        [HttpDelete("{coberturaId:int}", Name = "BorrarCobertura")]
        public IActionResult BorrarCobertura(int coberturaId)
        {
            if (!_cobRep.ExisteCobertura(coberturaId))
            {
                return NotFound();
            }
            var cobertura = _cobRep.GetCobertura(coberturaId);

            if (!_cobRep.BorrarCobertura(cobertura))
            {
                ModelState.AddModelError("", $"Algo salió mal borrando el registro{cobertura.NombreCobertura}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        
        [HttpGet("Buscar")]
        public IActionResult Buscar(string nombre)
        {
            try
            {
                var resultado = _cobRep.BuscarCobertura(nombre.Trim());
                if (resultado.Any())
                {
                    return Ok(resultado);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error recuperando datos");
            }

        }

      
        [HttpGet("GetCoberturaEnRamos/{nombreRamo}")]
        public IActionResult GetCoberturaEnRamos(string nombreRamo)
        {
            var listaCobertura = _cobRep.GetCoberturaEnRamos(nombreRamo);

            if (listaCobertura == null)
            {
                return NotFound();
            }

            var itemPelicula = new List<CoberturaDto>();

            foreach (var item in listaCobertura)
            {
                itemPelicula.Add(_mapper.Map<CoberturaDto>(item));
            }
            return Ok(itemPelicula);
        }

        [HttpGet("GetCoberturaId/{nombreRamo}")]
        public IActionResult GetCoberturaId(string nombreRamo)
        {
            // Llamar al método Getid para obtener el ID del ramo
            var ramoId = _cobRep.Getid(nombreRamo);

            // Si no se encuentra, devolvemos NotFound
            if (ramoId == null)
            {
                return NotFound();
            }

            // Devolvemos el ID del ramo en la respuesta
            return Ok(new { RamoId = ramoId });
        }




    }
}
