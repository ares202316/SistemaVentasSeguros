using AutoMapper;
using BackendSeguros.Models;
using BackendSeguros.Models.Dtos.CorredorDTO;
using BackendSeguros.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendSeguros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class CorredoresController : ControllerBase
    {


        private readonly ICorredorRepositorio _corRep;
        private readonly IMapper _mapper;

        public CorredoresController(ICorredorRepositorio corRep, IMapper mapper)
        {
            _corRep = corRep;
            _mapper = mapper;
        }


        
        [HttpGet]
        public IActionResult GetCorredores()
        {
            var listadeCorredor = _corRep.GetCorredores();
            var listaCorredorDTO = new List<CorredorDTO>();

            foreach (var lista in listadeCorredor)
            {
                listaCorredorDTO.Add(_mapper.Map<CorredorDTO>(lista));
            }

            return Ok(listaCorredorDTO);
        }


        
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CorredorDTO))]
        //Agregar las respuestas

        public IActionResult CrearCorredor([FromBody] CrearCorredorDTO crearCorredorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (crearCorredorDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (_corRep.ExisteDniCorredor(crearCorredorDTO.Dni))
            {
                ModelState.AddModelError("", "El dni es de valor unico");
                return StatusCode(404, ModelState);
            }

            

            if (_corRep.ExisteEmailCorredor(crearCorredorDTO.Email))
            {
                ModelState.AddModelError("", "El correo tiene que ser es de valor unico");
                return StatusCode(404, ModelState);
            }

            var corredor = _mapper.Map<Corredor>(crearCorredorDTO);

            if (!_corRep.CrearCorredor(corredor))
            {
                ModelState.AddModelError("", $"Algo salio mal al guardar el registro{corredor.CodCorredor}");
                return StatusCode(500, ModelState);
            }


            return new ObjectResult(corredor) { StatusCode = 201 };
        }

       
        [HttpPatch("{corredorId:int}", Name = "ActualizarCorredor")]
        //Agregar las respuestas

        public IActionResult ActualizarCorredor(int corredorId, [FromBody] CorredorDTO actualizarCorredorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var corredor = _mapper.Map<Corredor>(actualizarCorredorDTO);
            if (!_corRep.ActualizarCorredor(corredor))
            {
                ModelState.AddModelError("", $"Hubo un error inesperado al actualizar registro{corredor.CodCorredor}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        
        [HttpDelete("{corredorId:int}", Name = "BorrarCorredor")]
        public IActionResult BorrarCorredor(int corredorId)
        {
            if (!_corRep.ExisteCorredor(corredorId))
            {
                return NotFound();
            }
            var corredor = _corRep.GetCorredor(corredorId);

            if (!_corRep.BorrarCorredor(corredor))
            {
                ModelState.AddModelError("", $"Algo salió mal borrando el registro{corredor.CodCorredor}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

       
        [HttpGet("Buscar")]
        public IActionResult Buscar(string nombre)
        {
            try
            {
                var resultado = _corRep.BuscarCorredor(nombre.Trim().ToLower());
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
