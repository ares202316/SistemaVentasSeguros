using AutoMapper;
using BackendSeguros.Models;
using BackendSeguros.Models.Dtos.ClienteDTO;
using BackendSeguros.Models.Dtos.RamosDTO;
using BackendSeguros.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XAct;

namespace BackendSeguros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        private readonly IClienteRepositorio _Rep;
        private readonly IMapper _mapper;


        public ClientesController(IClienteRepositorio Rep, IMapper mapper)
        {
            _Rep = Rep;
            _mapper = mapper;
        }

        [HttpGet("Lista")]

        public IActionResult GetClientes()
        {
            var listaDatos = _Rep.GetClientes();
            var listaDto = new List<ClienteDto>();

            foreach (var lista in listaDatos)
            {
                listaDto.Add(_mapper.Map<ClienteDto>(lista));
            }

            return Ok(listaDto);
        }

        [HttpGet("{datoid:int}", Name = "GetCliente")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCliente(int datoid)
        {
            var itemRamo = _Rep.GetCliente(datoid);

            if (itemRamo == null)
            {
                return NotFound();
            }

            var itemUsuarioDto = _mapper.Map<ClienteDto>(itemRamo);

            return Ok(itemUsuarioDto);
        }



        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ClienteDto))]
        //Agregar las respuestas
        public IActionResult CrearCliente([FromBody] ClienteDto crearClienteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (crearClienteDto == null)
            {
                return BadRequest(ModelState);
            }
                      

            var cliente = _mapper.Map<Cliente>(crearClienteDto);

            if (!_Rep.CrearCliente(cliente))
            {
                ModelState.AddModelError("", $"Algo salio mal al guardar el registro{cliente.id}");
                return StatusCode(500, ModelState);
            }


            return new ObjectResult(cliente) { StatusCode = 201 };
        }


        [HttpPatch("{datosId:int}", Name = "ActualizarCliente")]
        //Agregar las respuestas

        public IActionResult ActualizarCliente(int datosId, [FromBody] ClienteDto clienteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            var cliente = _mapper.Map<Cliente>(clienteDto);
            if (!_Rep.ActualizarCliente(cliente))
            {
                ModelState.AddModelError("", $"Hubo un error inesperado al actualizar registro{cliente.Dni}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{clienteid:int}", Name = "BorrarCliente")]
        public IActionResult BorrarCliente(int clienteid)
        {
            if (!_Rep.ExisteCliente(clienteid))
            {
                return NotFound();
            }
            var cliente = _Rep.GetCliente(clienteid);

            if (!_Rep.BorrarCliente(cliente))
            {
                ModelState.AddModelError("", $"Algo salió mal borrando el registro{cliente.Dni}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpGet("Buscar")]
        public IActionResult Buscar(string nombre)
        {
            try
            {
                var resultado = _Rep.BuscarCliente(nombre.Trim());
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
