using AutoMapper;
using BackendSeguros.Models;
using BackendSeguros.Models.Dtos.RamosDTO;
using BackendSeguros.Models.Dtos.UsuarioDTO;
using BackendSeguros.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackendSeguros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    
    public class RamosController : ControllerBase
    {
        private readonly IRamoRepositorio _ramoRep;
        private readonly IMapper _mapper;

        public RamosController(IRamoRepositorio ramoRep, IMapper mapper)
        {
            _ramoRep = ramoRep;
            _mapper = mapper;
        }
      
        [HttpGet("Lista")]
        //Agregar las respuestas
        public IActionResult GetRamos()
        {
            var listaderamos = _ramoRep.GetRamos();
            var listaRamoDto = new List<RamoDto>();

            foreach (var lista in listaderamos)
            {
                listaRamoDto.Add(_mapper.Map<RamoDto>(lista));
            }

            return Ok(listaRamoDto);
        }

        [HttpGet("{ramoid:int}", Name = "GetRamo")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetRamo(int ramoid)
        {
            var itemRamo = _ramoRep.GetRamo(ramoid);

            if (itemRamo == null)
            {
                return NotFound();
            }

            var itemUsuarioDto = _mapper.Map<RamoDto>(itemRamo);

            return Ok(itemUsuarioDto);
        }



        [HttpPost]
        [ProducesResponseType(201, Type = typeof(RamoDto))]
        //Agregar las respuestas
        public IActionResult CrearRamo([FromBody] CrearRamoDto crearRamoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (crearRamoDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_ramoRep.ExisteRamo(crearRamoDto.NombreRamos))
            {
                ModelState.AddModelError("", "El tipo de ramo ya existe");
       
                return StatusCode(409, ModelState);
            }

            var ramo = _mapper.Map<Ramo>(crearRamoDto);

            if (!_ramoRep.CrearRamo(ramo))
            {
                ModelState.AddModelError("", $"Algo salió mal al guardar el registro {ramo.NombreRamos}");
                return StatusCode(500, ModelState);
            }

            return new ObjectResult(ramo) { StatusCode = 201 };
        }


        [HttpPatch("{ramoId:int}", Name ="ActualizarRamo")]
        //Agregar las respuestas

        public IActionResult ActualizarRamo(int ramoId, [FromBody] RamoDto ramoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            var ramo = _mapper.Map<Ramo>(ramoDto);
            if (!_ramoRep.ActualizarRamo(ramo))
            {
                ModelState.AddModelError("", $"Hubo un error inesperado al actualizar registro{ramo.NombreRamos}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        
        [HttpDelete("{ramoId:int}", Name = "BorrarRamo")]
        public IActionResult BorrarRamo(int ramoId)
        {
            if (!_ramoRep.ExisteRamo(ramoId))
            {
                return NotFound();
            }
            var ramo = _ramoRep.GetRamo(ramoId);

            if (!_ramoRep.BorrarRamo(ramo))
            {
                ModelState.AddModelError("", $"Algo salió mal borrando el registro{ramo.NombreRamos}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        
        [HttpGet("Buscar")]
        public IActionResult Buscar(string nombre)
        {
            try
            {
                var resultado = _ramoRep.BuscarRamo(nombre.Trim());
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



    }
}
