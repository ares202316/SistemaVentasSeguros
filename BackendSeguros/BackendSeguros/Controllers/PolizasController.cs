﻿using AutoMapper;
using BackendSeguros.Models;
using BackendSeguros.Models.Dtos.CoberturaDTO;
using BackendSeguros.Models.Dtos.PolizaDTO;
using BackendSeguros.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendSeguros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolizasController : ControllerBase
    {

        private readonly IPolizaRepositorio _Rep;
        private readonly IMapper _mapper;
        public PolizasController(IPolizaRepositorio Rep, IMapper mapper)
        {
            _Rep = Rep;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult GetPolizas([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 2)
        {
            try
            {
                var totalPolizas = _Rep.GetTotalPolizas();
                var polizas = _Rep.GetPolizas(pageNumber, pageSize);
                if (polizas == null  || !polizas.Any())
                {
                    return NotFound("No se encontraron poliza");
                }

                var polizasDto = polizas.Select(p => _mapper.Map<PolizaDatosGeneralDto>(p)).ToList();

                var response = new
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalPages = (int)Math.Ceiling(totalPolizas / (double)pageSize),
                    TotalItems = totalPolizas,
                    Items = polizasDto
                };

                return Ok(response);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error recuperando datos de la aplicación");
            }



        }

           [HttpPost]
         public IActionResult CrearPolizas([FromBody] CrearPolizaDto polizaDto)
        {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }
                    if (polizaDto == null)
                    {
                        return BadRequest(ModelState);
                    }


            var poliza = _mapper.Map<Poliza>(polizaDto);

                if (!_Rep.CrearPoliza(poliza))
                {
                    ModelState.AddModelError("", $"Algo salio mal al guardar el registro{poliza.codigo}");
                    return StatusCode(500, ModelState);
                }


                return new ObjectResult(poliza) { StatusCode = 201 };
        }

        [HttpPatch("{polizaid:int}", Name = "ActualizarPoliza")]
        public IActionResult ActualizarPoliza(int polizaid, [FromBody] PolizaDatosDto polizaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var poliza = _mapper.Map<Poliza>(polizaDto);
            if (!_Rep.ActualizarPoliza(poliza))
            {
                ModelState.AddModelError("", $"Hubo un error inesperado al actualizar registro{poliza.codigo}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

        

        [HttpDelete("{polizaid:int}", Name = "BorrarPolizas")]
        public IActionResult BorrarPolizas(int polizaid)
        {
            
            var poliza = _Rep.GetPoliza(polizaid);

            if (!_Rep.BorrarPoliza(poliza))
            {
                ModelState.AddModelError("", $"Algo salió mal borrando el registro{poliza.codigo}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }



        [HttpGet("Buscar")]
        public IActionResult Buscar(string nombre)
        {
            try
            {
                var resultado = _Rep.BuscarPoliza(nombre.Trim());
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
